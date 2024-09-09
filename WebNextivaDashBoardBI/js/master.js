Master = function () {
    var self = this;

    //--------------------------------------------------------------------------------
    //  Metodos destinados a inicializar el Editor
    //--------------------------------------------------------------------------------
    this.Initialize = function () {
        //self.LoadLoader();
        self.LoadMenu();

    }

    this.LoadMenu = function () {
        $("#nav > li > a").click(function (e) { // binding onclick
            if ($(this).parent().hasClass('selected')) {
                $("#nav .selected div div").slideUp(100); // hiding popups
                $("#nav .selected").removeClass("selected");
            } else {
                $("#nav .selected div div").slideUp(100); // hiding popups
                $("#nav .selected").removeClass("selected");

                if ($(this).next(".subs").length) {
                    $(this).parent().addClass("selected"); // display popup
                    $(this).next(".subs").children().slideDown(200);
                }
            }
            e.stopPropagation();
        });

        $("body").click(function () { // binding onclick to body
            $("#nav .selected div div").slideUp(100); // hiding popups
            $("#nav .selected").removeClass("selected");
        });


        $(document).click(function () { // binding onclick to body
            $("#nav .selected div div").slideUp(100); // hiding popups
            $("#nav .selected").removeClass("selected");
        });
    }
}
