using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SecantMethod.TableAdditional;
using SecantMethod.TableKoeffecientPlockosty;
using SecantMethod.TableRank;
using SecantMethod.TableSign;

namespace SecantMethod.TableServices
{

    public class ServiceTableRank
    {
        private static DataGridView _grid;
        private static List<SignTable> _signTables;
        private static List<RankTable> _rankTables;
        private static List<KoeffecientPlockostyTable> _koeffecientPlockostyTables;
        private static SericeTableAdditional _sericeTableAdditional;
        public ServiceTableRank(DataGridView grid, DataGridView gridAdditiona, List<SignTable> signTables,
            List<KoeffecientPlockostyTable> koeffecientPlockostyTables)
        {
            _grid = grid;
            _signTables = signTables;
            _rankTables = new List<RankTable>();
            _koeffecientPlockostyTables = koeffecientPlockostyTables;

            _sericeTableAdditional = new SericeTableAdditional(gridAdditiona, _rankTables, _koeffecientPlockostyTables, _signTables);
        }

        public static List<RankTable> RankTables
        {
            get { return _rankTables; }
        }

        public static void DisplayValues()
        {
            _grid.Rows.Add();

            for (int j = 0; j < _rankTables.Count; j++)
            {
                _grid[0, j].Value = _rankTables[j].NumberImage;
                _grid[1, j].Value = _rankTables[j].Class;
                _grid.Rows.Add();
            }

            for (int i = 0; i < _grid.RowCount - 2; i++)
            {
                var j = 2;

                foreach (var valueSign in _rankTables[i].DictionaryRank.Values)
                {
                    _grid[j, i].Value = valueSign;
                    j++;
                }

                j = 2;
            }
        }
        public static void CreateTable()
        {
            CreateHeaderTable(_koeffecientPlockostyTables.Count + 2);
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

            for (var i = 0; i < _koeffecientPlockostyTables.Count; i++)
            {
                _grid.Columns[i + 2].Name = string.Format("{0}", _koeffecientPlockostyTables[i].NumberPloskosty);
            }
        }

        public static void CalculatioRank()
        {
            InitializeTableRank();
            CreateFirstColumn();
            CalculationBetweenFirstAndLastPloskost();
            CalculationLastPloskost();
        }

        private static void CalculationLastPloskost()
        {
            _sericeTableAdditional.CreateTable();
            _sericeTableAdditional.SetValues();
            _sericeTableAdditional.DisplayValues();

            var additionalTable = _sericeTableAdditional.AdditionalTables;

            var listAdditional = new List<Tuple<string, string, int>>();

            foreach (var table in additionalTable)
            {
                string splitValue = null;

                foreach (var keyValuePair in table.DictionaryAdditionalRank)
                {
                    splitValue += keyValuePair.Value;
                }

                listAdditional.Add(new Tuple<string, string, int>(table.Class, splitValue, table.NumberImage));
            }

            var apponents = _sericeTableAdditional.FindApponetsAdditionlTable(listAdditional);

            SetRankForLastPloskosty(apponents);
        }

        private static void SetRankForLastPloskosty(IEnumerable<int> numbers)
        {
            var numberImages = numbers.Distinct();
            var lastPloskost = _koeffecientPlockostyTables.Last().NumberPloskosty;

            foreach (int number in numberImages)
            {
                foreach (var rankTable in _rankTables)
                {
                    if (rankTable.NumberImage == number)
                    {
                        rankTable.DictionaryRank[lastPloskost] = 0;
                    }
                }

            }
        }

        private static void CalculationBetweenFirstAndLastPloskost()
        {
            for (int i = 2; i < _koeffecientPlockostyTables.Count; i++)
            {
                var listSigns = new List<Tuple<string, string, int>>();
                int numberClosePloskosty = _koeffecientPlockostyTables[i - 1].NumberPloskosty;

                foreach (SignTable signsRow in _signTables)
                {
                    string splitValue = null;

                    foreach (var ploskost in signsRow.DictionaryPloskostei)
                    {
                        if (ploskost.Key > numberClosePloskosty)
                            splitValue += ploskost.Value;
                    }

                    listSigns.Add(new Tuple<string, string, int>(signsRow.Class, splitValue, signsRow.NumberImage));
                }

                FindOpponentsFirstBetweenLast(listSigns, numberClosePloskosty);
            }
        }

        private static void FindOpponentsFirstBetweenLast(List<Tuple<string, string, int>> list, int numberClosePloskosty)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].Item2 == list[j].Item2)
                    {
                        if (list[i].Item1 != list[j].Item1)
                        {
                            int numberOne = list[i].Item3;
                            int numberTwo = list[j].Item3;
                            string valuesSplitOne = list[i].Item2;
                            string valuesSplitTwo = list[j].Item2;

                            foreach (var numberPloskosty in _koeffecientPlockostyTables
                                .Where(x => x.NumberPloskosty < numberClosePloskosty)
                                .Select(x => x.NumberPloskosty))
                            {
                                var oneValues =
                                    _rankTables.Where(x => x.NumberImage == numberOne)
                                        .Select(rankTable => rankTable.DictionaryRank.Where(keyValuePair => keyValuePair.Key == numberPloskosty))
                                        .First().ToList();

                                var twoValues =
                                   _rankTables.Where(x => x.NumberImage == numberTwo)
                                       .Select(rankTable => rankTable.DictionaryRank.Where(keyValuePair => keyValuePair.Key == numberPloskosty))
                                       .First().ToList();

                                foreach (KeyValuePair<int, int> tuple in oneValues)
                                {
                                    if (oneValues.Where(x => x.Key == tuple.Key).Select(x => x.Value).First() == 0 && twoValues.Where(x => x.Key == tuple.Key).Select(x => x.Value).First() == 0)
                                    {
                                        valuesSplitOne += _signTables.Where(x => x.NumberImage == numberOne).
                                            Select(x => x).First().
                                            DictionaryPloskostei[tuple.Key];

                                        valuesSplitTwo += _signTables.Where(x => x.NumberImage == numberTwo).
                                            Select(x => x).First().
                                            DictionaryPloskostei[tuple.Key];
                                    }
                                }
                            }

                            if (valuesSplitOne == valuesSplitTwo)
                            {
                                _rankTables.Where(x => x.NumberImage == numberOne)
                                    .Select(x => x)
                                    .First()
                                    .DictionaryRank[numberClosePloskosty] = 0;

                                _rankTables.Where(x => x.NumberImage == numberTwo)
                                    .Select(x => x)
                                    .First()
                                    .DictionaryRank[numberClosePloskosty] = 0;
                            }
                        }

                    }
                }
            }
        }
        private static void CreateFirstColumn()
        {
            var listSigns = new List<KeyValuePair<string, string>>();

            for (int i = 1; i < _koeffecientPlockostyTables.Count; i++)
            {
                foreach (SignTable signsRow in _signTables)
                {
                    string splitValue = null;

                    foreach (var values in signsRow.DictionaryPloskostei)
                    {
                        int numberPloskosty = _koeffecientPlockostyTables.First().NumberPloskosty;

                        if (numberPloskosty != values.Key)
                            splitValue += values.Value;
                    }

                    listSigns.Add(new KeyValuePair<string, string>(signsRow.Class, splitValue));
                }

                FindOpponetsFirst(listSigns);

                listSigns.Clear();
            }
        }

        private static void FindOpponetsFirst(List<KeyValuePair<string, string>> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].Value == list[j].Value)
                    {
                        if (list[i].Key != list[j].Key)
                        {
                            _rankTables[i].DictionaryRank[_koeffecientPlockostyTables[0].NumberPloskosty] = 0;
                            _rankTables[j].DictionaryRank[_koeffecientPlockostyTables[0].NumberPloskosty] = 0;
                        }

                    }
                }
            }
        }

        private static void InitializeTableRank()
        {
            for (int i = 0; i < _signTables.Count; i++)
            {
                var rankTable = new RankTable
                {
                    DictionaryRank = new Dictionary<int, int>(),
                    Class = _signTables[i].Class,
                    NumberImage = _signTables[i].NumberImage
                };

                foreach (int numberPloskosty in _koeffecientPlockostyTables.Select(x => x.NumberPloskosty))
                {
                    rankTable.DictionaryRank.Add(numberPloskosty, 1);
                }

                _rankTables.Add(rankTable);
            }
        }


        public static void DeleteIdenticRow()
        {
            var ids = new List<int>();

            for (int i = 0; i < _rankTables.Count; i++)
            {
                for (int j = i + 1; j < _rankTables.Count; j++)
                {
                    if (_rankTables[i].Class == _rankTables[j].Class)
                    {
                        if (CompareIdentityRow(_rankTables[i], _rankTables[j]) != null)
                        {
                            var idsCompare = CompareIdentityRow(_rankTables[i], _rankTables[j]);

                            ids.Add(idsCompare[0]);
                            ids.Add(idsCompare[1]);

                            CheckTableSignZnachRank(ids);

                            ids.Clear();
                        }
                    }
                }
            }

            DeleteIdentityTableRow();

        }

        private static int[] CompareIdentityRow(RankTable left, RankTable right)
        {
            string leftRow = left.DictionaryRank.Aggregate<KeyValuePair<int, int>, string>(null, (current, i) => current + i.Value);
            string rightRow = right.DictionaryRank.Aggregate<KeyValuePair<int, int>, string>(null, (current, i) => current + i.Value);


            if (leftRow == rightRow)
            {
                return new[] { left.NumberImage, right.NumberImage };
            }

            return null;
        }


        private static void CheckTableSignZnachRank(List<int> ids)
        {
            RankTable oneRow = _rankTables.Find(x => x.NumberImage == ids[0]);

            var listPosition = (from variable in oneRow.DictionaryRank where variable.Value == 0 select variable.Key).ToList();

            SignTable oneRowSign = _signTables.Find(x => x.NumberImage == ids[0]);
            SignTable twoRowSign = _signTables.Find(x => x.NumberImage == ids[1]);


            int countIdentity = 0;

            foreach (var i in listPosition)
            {
                if (oneRowSign.DictionaryPloskostei[i] == twoRowSign.DictionaryPloskostei[i])
                {
                    countIdentity++;
                }
            }

            if (countIdentity == listPosition.Count)
            {
                twoRowSign.IsDeleted = 1;
            }

        }

        private static void DeleteIdentityTableRow()
        {
            var ids = _signTables.Where(x => x.IsDeleted == 1).Select(x => x.NumberImage);

            foreach (var id in ids)
            {
                _rankTables.Find(x => x.NumberImage == id).IsDeleted = 1;
            }

            _rankTables.RemoveAll(x => x.IsDeleted == 1);
            _signTables.RemoveAll(x => x.IsDeleted == 1);
        }
    }
}