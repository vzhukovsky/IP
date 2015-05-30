using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SecantMethod.Services;
using SecantMethod.TableKoeffecientPlockosty;
using SecantMethod.TablePriznakov;
using SecantMethod.TableSign;

namespace SecantMethod.TableServices
{
    public class ServiceTableSigns
    {
        private static DataGridView _grid;
        private static List<KoeffecientPlockostyTable> _koeffecientPlockosty;
        private static List<SignTable> _signTables;
        private static List<PriznakTable> _priznakTables;


        public ServiceTableSigns(DataGridView grid, List<KoeffecientPlockostyTable> koeffecientPlockostyTables,
            List<SignTable> signTables, List<PriznakTable> priznakTables)
        {
            _koeffecientPlockosty = koeffecientPlockostyTables;
            _signTables = signTables;
            _priznakTables = priznakTables;

            //Initial Grid
            _grid = grid;
        }

        public static List<SignTable> SignTables
        {
            get { return _signTables; }
            set { _signTables = value; }
        }

        public static List<KoeffecientPlockostyTable> KoeffecientPlockosty
        {
            get { return _koeffecientPlockosty; }
        }

        public static void DisplayZnazhRazr()
        {
            var rankTable = ServiceTableRank.RankTables;

            for (int rowIndex = 0; rowIndex < rankTable.Count; rowIndex++)
            {
                foreach (var keyValuePair in rankTable[rowIndex].DictionaryRank)
                {
                    if (keyValuePair.Value == 0)
                    {
                        var findColumn = 0;

                        for (int i = 0; i < _koeffecientPlockosty.Count; i++)
                        {
                            if (_koeffecientPlockosty[i].NumberPloskosty == keyValuePair.Key)
                            {
                                findColumn = i;
                                break;
                            }
                        }

                        _grid[2 + findColumn, rowIndex].Style.BackColor = Color.Green;
                    }
                }
            }
        }

        public static void SokrashSignTable()
        {
            var listSigns = new List<KeyValuePair<string, string>>(); ;
            var numbersDeletedPloskosty = new List<int>();

            for (int i = 0; i < _koeffecientPlockosty.Count; i++)
            {
                foreach (SignTable signsRow in _signTables)
                {
                    string splitValue = null;

                    foreach (var values in signsRow.DictionaryPloskostei)
                    {
                        if (i + 1 != values.Key)
                            splitValue += values.Value;
                    }

                    listSigns.Add(new KeyValuePair<string, string>(signsRow.Class, splitValue));
                }

                if (IsOponents(listSigns))
                {
                    numbersDeletedPloskosty.Add(i + 1);

                    foreach (Dictionary<int, int> signTable in _signTables.Select(x => x.DictionaryPloskostei))
                    {
                        signTable.Remove(i + 1);
                    }

                    var deletePloskost = _koeffecientPlockosty.First(x => x.NumberPloskosty == i + 1);
                    _koeffecientPlockosty.Remove(deletePloskost);
                }

                listSigns.Clear();
            }

            DeleteDuplicateRecord();

        }

        private static void DeleteDuplicateRecord()
        {
            var listSigns = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < _koeffecientPlockosty.Count; i++)
            {
                foreach (SignTable signsRow in _signTables)
                {
                    string splitValue = null;

                    foreach (var values in signsRow.DictionaryPloskostei)
                    {
                        splitValue += values.Value;
                    }

                    listSigns.Add(new KeyValuePair<string, string>(signsRow.Class, splitValue));
                }

                DuplicateRecords(listSigns);

                listSigns.Clear();
            }
        }

        private static void DuplicateRecords(List<KeyValuePair<string, string>> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].Value == list[j].Value)
                    {
                        if (list[i].Key == list[j].Key)
                        {
                            var signRecord = _signTables.Find(x => x.NumberImage == j + 1);
                            _signTables.Remove(signRecord);
                        }
                    }
                }
            }
        }
        private static bool IsOponents(List<KeyValuePair<string, string>> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].Value == list[j].Value)
                    {
                        if (list[i].Key != list[j].Key)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static void BuildTable()
        {
            CreateHeaderTable(_koeffecientPlockosty.Count + 2);

            _grid.Rows.Add();

            for (int j = 0; j < _signTables.Count; j++)
            {
                _grid[0, j].Value = _signTables[j].NumberImage;
                _grid[1, j].Value = _signTables[j].Class;
                _grid.Rows.Add();
            }

            for (int i = 0; i < _grid.RowCount - 2; i++)
            {
                var j = 2;

                foreach (var signTable in _signTables[i].DictionaryPloskostei.Values)
                {
                    _grid[j, i].Value = signTable;
                    j++;
                }

                j = 2;
            }
        }

        private static void CreateHeaderTable(int countColumn)
        {
            _grid.ColumnCount = countColumn;
            _grid.ColumnHeadersVisible = true;
            _grid.RowHeadersVisible = true;

            var columnHeaderStyle = new DataGridViewCellStyle
            {
                BackColor = Color.Beige,
                Font = new Font("Verdana", 10, FontStyle.Bold)
            };

            _grid.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            for (int i = 0; i < _grid.ColumnCount; i++)
            {
                _grid.Columns[i].Width = 60;
            }

            _grid.Columns[0].Name = "N";
            _grid.Columns[1].Name = "Class";

            for (var i = 0; i < _koeffecientPlockosty.Count; i++)
            {
                _grid.Columns[i + 2].Name = string.Format("{0}", _koeffecientPlockosty[i].NumberPloskosty);
            }
        }
        public static void AddPriznak(PriznakTable priznak)
        {
            AddPointInTableSing(priznak);

            var listSignApponents = FindOpponents();

            if (listSignApponents == null)
            {
                return;
            }

            var listPriznaksApponent = Priznak.GetPriznaks(_priznakTables, listSignApponents);

            KoeffecientPlockostyTable newKoeffPloskosty = Ploskosti.CreateNewPloskost(listPriznaksApponent, listSignApponents, _koeffecientPlockosty);
            CalculateSignForNewPolskost(newKoeffPloskosty);
        }


        public static void FindApponetsFinal()
        {
            var listSignApponents = FindOpponents();

            if (listSignApponents == null)
            {
                return;
            }

            var listPriznaksApponent = Priznak.GetPriznaks(_priznakTables, listSignApponents);

            KoeffecientPlockostyTable newKoeffPloskosty = Ploskosti.CreateNewPloskost(listPriznaksApponent, listSignApponents, _koeffecientPlockosty);
            CalculateSignForNewPolskost(newKoeffPloskosty);

        }
        private static void CalculateSignForNewPolskost(KoeffecientPlockostyTable newKoeffPloskosty)
        {
            foreach (var signTable in _signTables)
            {
                var priznak = _priznakTables.First(x => x.Number == signTable.NumberImage);
                var sign = CalculateSign(newKoeffPloskosty, priznak);
                signTable.DictionaryPloskostei.Add(newKoeffPloskosty.NumberPloskosty, sign);
            }
        }

        public static void AddPointInTableSing(PriznakTable priznak)
        {
            var countPloskostei = _koeffecientPlockosty.Count;

            var signTable = new SignTable();

            for (int i = 0; i < countPloskostei; i++)
            {
                var sign = CalculateSign(_koeffecientPlockosty[i], priznak);

                signTable.NumberImage = priznak.Number;
                signTable.Class = priznak.Class;

                if (signTable.DictionaryPloskostei == null)
                {
                    signTable.DictionaryPloskostei = new Dictionary<int, int>();
                }

                signTable.DictionaryPloskostei.Add(_koeffecientPlockosty[i].NumberPloskosty, sign);
            }

            _signTables.Add(signTable);
        }

        private static int CalculateSign(KoeffecientPlockostyTable koeffecientPlockosty, PriznakTable priznak)
        {
            var s1 = 0;

            var valuesFirst = priznak.Priznaki.Select(x => x.Value).ToList();
            var valueKoeff = koeffecientPlockosty.DictionaryLamda.Select(x => x.Value).ToList();

            for (var i = 0; i < valueKoeff.Count; i++)
            {
                s1 += (int)valueKoeff[i] * (int)valuesFirst[i];
            }

            var sign = s1 - koeffecientPlockosty.LamdaPlus1 > 0 ? 1 : 0;


            return sign;

        }


        public static List<SignTable> FindOpponents()
        {
            SignTable priznak = _signTables.Last();

            var list = new List<SignTable>();

            //find 

            for (var i = _signTables.Count - 2; i >= 0; i--)
            {
                if (_signTables[i].Class != priznak.Class)
                {
                    list.Add(_signTables[i]);
                }
            }

            var listApponents = new List<SignTable>();

            var counFind = 0;

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j <= priznak.DictionaryPloskostei.Count; j++)
                {
                    if (list[i].DictionaryPloskostei[j] == priznak.DictionaryPloskostei[j])
                    {
                        counFind++;
                    }
                }

                if (counFind == priznak.DictionaryPloskostei.Count)
                {
                    listApponents.Add(list[i]);
                    listApponents.Add(priznak);
                    return listApponents;
                }

                counFind = 0;
            }
            return null;
        }


    }
}
