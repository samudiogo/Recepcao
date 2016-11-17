using System.Web.Optimization;

namespace DPGERJ.Recepcao.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                @"~/Content/datatables/DataTables-1.10.12/js/jquery.dataTables.js",
                @"~/Content/datatables/DataTables-1.10.12/js/dataTables.bootstrap.js",
                @"~/Content/datatables/Responsive-2.1.0/js/dataTables.responsive.js"
                ));

            bundles.Add(new StyleBundle("~/Content/datatables/css").Include(
                @"~/Content/datatables/DataTables-1.10.12/css/dataTables.bootstrap.css",
                @"~/Content/datatables/Responsive-2.1.0/css/responsive.bootstrap.css"
                ));
        }
    }
}