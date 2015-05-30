using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SecantMethod.TableServices
{
    public abstract class ServiceTableBase<T> where T : class
    {
        private readonly int _countColum;
        private readonly List<string> _listHeaders;

        protected readonly DataGridView Grid;
        public int CountColum
        {
            get { return _countColum; }
        }

        protected ServiceTableBase(int countColum, List<string> listHeaders, DataGridView grid)
        {
            _countColum = countColum;
            _listHeaders = listHeaders;
            Grid = grid;
        }

        protected ServiceTableBase()
        {
            throw new System.NotImplementedException();
        }

        public void BuildGrid()
        {
            Grid.ColumnCount = _listHeaders.Count;
            Grid.ColumnHeadersVisible = true;
            Grid.RowHeadersVisible = true;

            var columnHeaderStyle = new DataGridViewCellStyle
            {
                BackColor = Color.Beige,
                Font = new Font("Verdana", 10, FontStyle.Bold)
            };

            Grid.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            for (int i = 0; i < Grid.ColumnCount; i++)
            {
                Grid.Columns[i].Width = 60;
            }

            CreateHeaders(_listHeaders);
        }

        private void CreateHeaders(IReadOnlyList<string> listHeader)
        {
            for (var i = 0; i < Grid.ColumnCount; i++)
            {
                Grid.Columns[i].Name = listHeader[i];
            }
        }

        public List<T> GetValues()
        {
            var list = new List<T>();

            for (int i = 0; i < Grid.RowCount; i++)
            {
                list.Add(GetRowValues(i, Grid.ColumnCount));
            }

            return list;
        }

        protected abstract T GetRowValues(int row, int col);
        public abstract void AddValueTable(List<T> listValues);
    }
}