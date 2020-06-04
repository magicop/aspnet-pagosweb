using System.Web;
using System.Web.Optimization;

namespace WebPagos
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            #region Bundles
            // Crea paquetes para almacenar los scripts y css

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js",
            "~/Scripts/jquery-ui-dialog.js",
            "~/Scripts/pagosweb.js"));

            bundles.Add(new ScriptBundle("~/bundles/validation").Include(
            "~/Scripts/jquery.validate.js",
            "~/Scripts/additional-validation.js",
            "~/Scripts/buzon-web-validation.js"));

            bundles.Add(new StyleBundle("~/Banmedica/css").Include(
            "~/Content/jquery-ui.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
            "~/Scripts/jquery.dataTables.js",
            "~/Scripts/dataTables.buttons.js",
            "~/Scripts/jszip.js",
            "~/Scripts/pdfmake.js",
            "~/Scripts/vfs_fonts.js",
            "~/Scripts/buttons.html5.js",
            "~/Scripts/buttons.colVis.js",
            "~/Scripts/buttons.print.js"));

            bundles.Add(new StyleBundle("~/Helpers/css").Include(
              "~/Content/datatables.css",
              "~/Content/jquery.dataTables.css",
              "~/Content/buttons.dataTables.css"));

            #endregion
        }
    }
}
