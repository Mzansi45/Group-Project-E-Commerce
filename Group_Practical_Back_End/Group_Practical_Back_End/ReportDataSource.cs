using System.Data;

namespace Group_Practical_Back_End
{
    internal class ReportDataSource
    {
        private string v;
        private DataTable dt;

        public ReportDataSource(string v, DataTable dt)
        {
            this.v = v;
            this.dt = dt;
        }
    }
}