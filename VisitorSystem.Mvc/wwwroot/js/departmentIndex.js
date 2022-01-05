$(document).ready(function () {

    /* DataTables start here. */

    $('#departmentsTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Ekle',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {
                }
            },
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/Department/GetAllDepartments/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#departmentsTable').hide();
                           
                        },
                        success: function (data) {
                            const departmentsDto = jQuery.parseJSON(data);
                            console.log(departmentsDto);
                            if (departmentsDto.ResultStatus === 0) {
                                let tableBody = "";
                                $.each(departmentsDto.Departments.$values,
                                    function (index, department) {
                                        tableBody += `
                                                <tr>
                                    <td>${department.Id}</td>
                                    <td>${department.Name}</td>
                                    <td>${department.CountactNo}</td>
                                    <td>${convertFirstLetterToUpperCase(department.IsActive.toString())}</td>
                                    <td>${convertFirstLetterToUpperCase(department.IsDeleted.toString())}</td>
                                   
                                    
                                    <td>${department.CreatedByName}</td>
                                     <td>${convertToShortDate(department.CreatedDate)}</td>
                                  
                                    <td>${department.ModifiedByName}</td>
                                    <td>${convertToShortDate(department.ModifiedDate)}</td>

                                    <td>
                                <button class="btn btn-primary  btn-block btn-sm btn-update" data-id="${department.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger   btn-block btn-sm btn-delete" data-id="${department.Id}"><span class="fas fa-minus-circle"></span></button>
                                    </td>
                                            </tr>`;
                                    });
                                $('#departmentsTable > tbody').replaceWith(tableBody);
                              
                                $('#departmentsTable').fadeIn(1400);
                            } else {
                                toastr.error(`${departmentsDto.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                           
                            $('#departmentsTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Hata!');
                        }
                    });
                }
            }
        ],
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }
    });

    /* DataTables end here */

    /* Ajax GET / Getting the _CategoryAddPartial as Modal Form starts from here. */

    $(function () {
        const url = '/Admin/Department/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        /* Ajax GET / Getting the _CategoryAddPartial as Modal Form ends here. */

        /* Ajax POST / Posting the FormData as CategoryAddDto starts from here. */

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                const form = $('#form-department-add');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    console.log(data);
                    const departmentAddAjaxModel = jQuery.parseJSON(data);
                    console.log(departmentAddAjaxModel);
                    const newFormBody = $('.modal-body', departmentAddAjaxModel.DepartmentAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = `
                                <tr name="${departmentAddAjaxModel.DepartmentDto.Department.Id}">
                                                    <td>${departmentAddAjaxModel.DepartmentDto.Department.Id}</td>
                                                    <td>${departmentAddAjaxModel.DepartmentDto.Department.Name}</td>

                                                     <td>${departmentAddAjaxModel.DepartmentDto.Department.CountactNo}</td>
                                                    <td>${convertFirstLetterToUpperCase(departmentAddAjaxModel.DepartmentDto.Department.IsActive.toString())}</td>
                                                    <td>${convertFirstLetterToUpperCase(departmentAddAjaxModel.DepartmentDto.Department.IsDeleted.toString())}</td>
                                                                                                     
                                                    <td>${departmentAddAjaxModel.DepartmentDto.Department.CreatedByName}</td>
                                                    <td>${convertToShortDate(departmentAddAjaxModel.DepartmentDto.Department.CreatedDate)}</td>

                                                   <td>${departmentAddAjaxModel.DepartmentDto.Department.ModifiedByName}</td>
                                                    <td>${convertToShortDate(departmentAddAjaxModel.DepartmentDto.Department.ModifiedDate)}</td>
                                                    <td>
                                                        <button class="btn btn-primary btn-block btn-sm btn-update" data-id="${departmentAddAjaxModel.DepartmentDto.Department.Id}"><span class="fas fa-edit"></span></button>
                                                        <button class="btn btn-danger btn-block btn-sm btn-delete" data-id="${departmentAddAjaxModel.DepartmentDto.Department.Id}"><span class="fas fa-minus-circle"></span></button>
                                                    </td>
                                                </tr>`;
                        const newTableRowObject = $(newTableRow);
                        newTableRowObject.hide();
                        $('#departmentsTable').append(newTableRowObject);
                        newTableRowObject.fadeIn(3500);
                        toastr.success(`${departmentAddAjaxModel.DeparmentDto.Message}`, 'Başarılı İşlem!');
                    } else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                });
            });
    });

    /* Ajax POST / Posting the FormData as CategoryAddDto ends here. */

    /* Ajax POST / Deleting a Category starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const departmentName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${departmentName} adlı birim silinicektir!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, silmek istiyorum.',
                cancelButtonText: 'Hayır, silmek istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { departmentId: id },
                        url: '/Admin/Department/Delete/',
                        success: function (data) {
                            const departmentDto = jQuery.parseJSON(data);
                            if (departmentDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${departmentDto.Department.Name} adlı birim başarıyla silinmiştir.`,
                                    'success'
                                );

                                tableRow.fadeOut(1000);
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${departmentDto.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Hata!")
                        }
                    });
                }
            });
        });

    /* Ajax GET / Getting the _CategoryUpdatePartial as Modal Form starts from here. */

    $(function () {
        const url = '/Admin/Department/Update/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click',
            '.btn-update',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                $.get(url, { departmentId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    toastr.error("Bir hata oluştu.");
                });
            });

        /* Ajax POST / Updating a Category starts from here */

        placeHolderDiv.on('click',
            '#btnUpdate',
            function (event) {
                event.preventDefault();

                const form = $('#form-department-update');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    const departmentUpdateAjaxModel = jQuery.parseJSON(data);
                    console.log(departmentUpdateAjaxModel);
                    const newFormBody = $('.modal-body', departmentUpdateAjaxModel.DepartmentUpdatePartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = `
                                <tr name="${departmentUpdateAjaxModel.DepartmentDto.Department.Id}">
                                                      <td>${departmentAddAjaxModel.DepartmentDto.Department.Id}</td>
                                                    <td>${departmentAddAjaxModel.DepartmentDto.Department.Name}</td>

                                                     <td>${departmentAddAjaxModel.DepartmentDto.Department.CountactNo}</td>
                                                    <td>${convertFirstLetterToUpperCase(departmentAddAjaxModel.DepartmentDto.Department.IsActive.toString())}</td>
                                                    <td>${convertFirstLetterToUpperCase(departmentAddAjaxModel.DepartmentDto.Department.IsDeleted.toString())}</td>
                                                    
                                                    <td>${convertToShortDate(departmentAddAjaxModel.DepartmentDto.Department.CreatedDate)}</td>
                                                    <td>${departmentAddAjaxModel.DepartmentDto.Department.CreatedByName}</td>
                                                    <td>${convertToShortDate(departmentAddAjaxModel.DepartmentDto.Department.ModifiedDate)}</td>
                                                    <td>${departmentAddAjaxModel.DepartmentDto.Department.ModifiedByName}</td>
                                                  
                                                    <td>
                                                        <button class="btn btn-primary btn-sm btn-update" data-id="${departmentUpdateAjaxModel.DepartmentDto.Department.Id}"><span class="fas fa-edit"></span></button>
                                                        <button class="btn btn-danger btn-sm btn-delete" data-id="${departmentUpdateAjaxModel.DepartmentDto.Department.Id
                            }"><span class="fas fa-minus-circle"></span></button>
                                                    </td>
                                                </tr>`;
                        const newTableRowObject = $(newTableRow);
                        const departmentTableRow = $(`[name="${departmentUpdateAjaxModel.DepartmentDto.Department.Id}"]`);
                        newTableRowObject.hide();
                        departmentTableRow.replaceWith(newTableRowObject);
                        newTableRowObject.fadeIn(3500);
                        toastr.success(`${departmentUpdateAjaxModel.DepartmentDto.Message}`, "Başarılı İşlem!");
                    } else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                }).fail(function (response) {
                    console.log(response);
                });
            });

    });
});