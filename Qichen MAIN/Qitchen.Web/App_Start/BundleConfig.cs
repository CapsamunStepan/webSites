using System.Web;
using System.Web.Optimization;

namespace Qichen.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            //------STYLES--------
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                   "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/jquery-ui.theme/css").Include(
                   "~/Content/jquery-ui.theme.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include(
                   "~/Content/font-awesome.css",new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/flaticon/css").Include(
                   "~/Content/flaticon.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/jquery/css").Include(
                   "~/Content/jquery-ui.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/animate/css").Include(
                   "~/Content/animate.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/magnific-popup/css").Include(
                   "~/Content/magnific-popup.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/nice-select/css").Include(
                   "~/Content/nice-select.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/Site/css").Include(
                   "~/Content/Site.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/slick/css").Include(
                   "~/Content/slick.css", new CssRewriteUrlTransform()));

            //-------Custom CSS-------//

            bundles.Add(new StyleBundle("~/bundles/default/css").Include(
                   "~/Vendor/css/default.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/style/css").Include(
                   "~/Vendor/css/style.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/_cart-checkout/css").Include(
                   "~/Vendor/css/sections/_cart-checkout.css", new CssRewriteUrlTransform()));




            //-------SCRIPTS--------------//

            bundles.Add(new Bundle("~/bundles/jquery/js").Include(
                "~/Scripts/jquery-3.6.4.min.js"));

            bundles.Add(new Bundle("~/bundles/jquery-ui/js").Include(
                "~/Scripts/jquery-ui-1.13.2.js"));

            bundles.Add(new Bundle("~/bundles/bootstrap/js").Include(
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new Bundle("~/bundles/modernizr/js").Include(
                "~/Scripts/modernizr-2.8.3.js"));

            bundles.Add(new Bundle("~/bundles/popper/js").Include(
                "~/Scripts/popper.min.js"));

            bundles.Add(new Bundle("~/bundles/slick/js").Include(
                "~/Scripts/slick.min.js"));

            bundles.Add(new Bundle("~/bundles/wow/js").Include(
                "~/Scripts/wow.min.js"));

            bundles.Add(new Bundle("~/bundles/jquery-counterup/js").Include(
                "~/Scripts/jquery.counterup.min.js"));

            bundles.Add(new Bundle("~/bundles/jquery-waypoints/js").Include(
               "~/Scripts/jquery.waypoints.js"));
            
            bundles.Add(new Bundle("~/bundles/jquery-nice-select/js").Include(
               "~/Scripts/jquery.nice-select.min.js"));

            bundles.Add(new Bundle("~/bundles/jquery-nice-number/js").Include(
               "~/Scripts/jquery.nice-number.min.js"));

            bundles.Add(new Bundle("~/bundles/isotope/js").Include(
            "~/Scripts/isotope.min.js"));

            bundles.Add(new Bundle("~/bundles/imagesloaded/js").Include(
           "~/Scripts/imagesloaded.min.js"));

            //-------Custom Scripts-----------//
            bundles.Add(new Bundle("~/bundles/theme/js").Include(
                "~/Vendor/js/theme.js"));
        }
    }
}
