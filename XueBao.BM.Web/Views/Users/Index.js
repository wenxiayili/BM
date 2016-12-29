(function() {
    $(function() {

        var _userService = abp.services.app.user;
        var _$modal = $('#UserCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate();

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var user = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            
            abp.ui.setBusy(_$modal);
            _userService.createUser(user).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        //set checkbox state
        $('input[name="CheckAll"]').on('click', function () {
            if ($('input[name="CheckAll"]').is(':checked')) {
                $('.row').find('table').find('input[type="checkbox"]').each(function () {
                    $(this).prop('checked', true);

                });
            }
            else {
                $('.row').find('table').find('input[type="checkbox"]').each(function () {
                    $(this).prop('checked', false);

                });
            }
        });

        

    
    });
})();

//以下的的代码是为了获取被选中的checkbox的value值
var _$table = $('.row').find('table').find('input[type="checkbox"]:checked');
var array = new Array();
var index = 0;
_$table.each(function () {
    if ($(this).val() != "") {
        array[index] = $(this).val();
        index++;

    }
});