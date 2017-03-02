$(document)
    .ready(function () {
        $(function () { // will trigger when the document is ready
            $('.datepicker').datepicker({
                format: 'mm/dd/yyyy',
                orientation: 'bottom',
                autoclose: 'true'
            }

                ); //Initialise any date pickers
        });
    });