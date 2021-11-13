$(document).ready(function () {
    SomeeAdsRemover();
    adsRemover();
});

function SomeeAdsRemover() {
    $("center").each(function () {
        if ($(this).html() == '<a href="http://somee.com">Web hosting by Somee.com</a>') {
            $('script[src="http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js"]').remove();
            $('script#last-script').nextAll('div').remove(); // last tag before </body>   
            $(this).next().remove();
            $(this).next().next().remove();
            $(this).next().next().next().remove();
            $(this).remove();

            return false;
        }
    });
}

function adsRemover() {
    $('body > div:last-child').remove();
}