(function () {
    $(function () {
        var _userService = abp.services.app.user;
        var _$modal = $('#UserCreateModal');
        var _$form = _$modal.find('form[name=userCreateForm]');
        var _$table = $('div >table button'); //table中的button按钮

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


       
        


        //edit user permission

           //bind click event for button of _$table
        _$table.on('click', function () {
            getHtmlString();
        });

        var _$editModal = $('#EditPermission');
        var _$editForm = _$editModal.find('form');

        _$editForm.validate();
        
        _$editForm.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$editForm.valid()) {
                return;
            }
            
            //get checked input value

            abp.ui.setBusy(_$editModal);
            
            //call services mothod to save permission
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

        //get all checked input's vlue
        getAllCheckedInputValue = function () {
            
            var _$table = $('.row').find('table').find('input[type="checkbox"]:checked');
            var array = new Array();
            var index = 0;
            _$table.each(function () {
                if ($(this).val() !== "") {
                    array[index] = $(this).val();
                    index++;
                }
            });
            return array;
        }

        //delete user
        $('.delete').click(function (e) {
            e.preventDefault();
            var userArray = getAllCheckedInputValue();
            if (userArray > 1) {
                _userService.batchDeleteUsersAsync(userArray)
                .done(function () {
                    location.reload(true); //reload page to see new user!
                })
            } else {
                var userId = userArray[0];
                _userService.deleteUser({ id: userId })
                .done(function () {
                    location.reload(true);
                });
            }
        });

        //get granted permission and get html string of Permission
        //
        var getHtmlString = function () {
            var grantedPermissionObject = abp.auth.grantedPermissions;
            var allPermissionObject = abp.auth.allPermissions;

            //building html string 
            var strHtml = "";
            for (permission in allPermissionObject)
            {
                strHtml = strHtml + '<li><input type="checkbox" value="' + permission + '"/>' + permission + '</li>';
            }

            _$editForm.find("ul").html(strHtml);

            //granted checkbox
            for(permission in grantedPermissionObject)
            {
                _$editForm.find('input[value ="' + permission + '"]').prop('checked', true);
            }
        }
    });
})();