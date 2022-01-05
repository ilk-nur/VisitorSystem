$(document).ready(function () {
    const dataTable = $('#visitorsTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Ziyaretçi Ekle',
                attr: {
                    id: "btnAdd"
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
                        url: '/Admin/Visitor/GetAllVisitor/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#visitorsTable').hide();

                        },
                        success: function (data) {
                            const visitorListDto = jQuery.parseJSON(data);
                            dataTable.clear();
                            console.log(visitorListDto);
                            if (visitorListDto.ResultStatus === 0) {
                                $.each(visitorListDto.Visitors.$values,
                                    function (index, visitor) {
                                        const newTableRow = dataTable.row.add([
                                            visitor.TcNo,
                                            visitor.FirstName,
                                            visitor.LastName,
                                            moment(visitor.BirthDate).format('YYYY-MM-DD'),
                                            visitor.ContactNo,
                                            moment(visitor.EnterDate).format('YYYY-MM-DD hh:mm'),
                                            visitor.IsExit == false ? 'Çıkış Yapmadı' : moment(visitor.OutDate).format('YYYY-MM-DD hh:mm'),
                                            visitor.Department.Name,                                           
                                           
                                            `
                                <button class="btn btn-primary btn-block btn-sm btn-update" data-id="${visitor.Id}"  style="background-color:blue; border-color:blue"><span class="fas fa-sign-in-alt"></span></button>
                                <button class="btn btn-danger btn-block btn-sm btn-delete" data-id="${visitor.Id}"><span class="fas fa-minus-circle"></span></button>
                                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${visitor.Id}`);
                                    });
                                dataTable.draw();

                                $('#visitorsTable').fadeIn(1400);
                            } else {
                                toastr.error(`${visitorListDto.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#visitorsTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Hata!');
                        }
                    });
                }



            }
        ],
        language: {
            "emptyTable": "Tabloda herhangi bir veri mevcut değil",
            "info": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "infoEmpty": "Kayıt yok",
            "infoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "infoThousands": ".",
            "lengthMenu": "Sayfada _MENU_ kayıt göster",
            "loadingRecords": "Yükleniyor...",
            "processing": "İşleniyor...",
            "search": "Ara:",
            "zeroRecords": "Eşleşen kayıt bulunamadı",
            "paginate": {
                "first": "İlk",
                "last": "Son",
                "next": "Sonraki",
                "previous": "Önceki"
            },
            "aria": {
                "sortAscending": ": artan sütun sıralamasını aktifleştir",
                "sortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "1": "1 kayıt seçildi"
                },
                "cells": {
                    "1": "1 hücre seçildi",
                    "_": "%d hücre seçildi"
                },
                "columns": {
                    "1": "1 sütun seçildi",
                    "_": "%d sütun seçildi"
                }
            },
            "autoFill": {
                "cancel": "İptal",
                "fillHorizontal": "Hücreleri yatay olarak doldur",
                "fillVertical": "Hücreleri dikey olarak doldur",
                "fill": "Bütün hücreleri <i>%d<\/i> ile doldur"
            },
            "buttons": {
                "collection": "Koleksiyon <span class=\"ui-button-icon-primary ui-icon ui-icon-triangle-1-s\"><\/span>",
                "colvis": "Sütun görünürlüğü",
                "colvisRestore": "Görünürlüğü eski haline getir",
                "copySuccess": {
                    "1": "1 satır panoya kopyalandı",
                    "_": "%ds satır panoya kopyalandı"
                },
                "copyTitle": "Panoya kopyala",
                "csv": "CSV",
                "excel": "Excel",
                "pageLength": {
                    "-1": "Bütün satırları göster",
                    "_": "%d satır göster"
                },
                "pdf": "PDF",
                "print": "Yazdır",
                "copy": "Kopyala",
                "copyKeys": "Tablodaki veriyi kopyalamak için CTRL veya u2318 + C tuşlarına basınız. İptal etmek için bu mesaja tıklayın veya escape tuşuna basın."
            },
            "searchBuilder": {
                "add": "Koşul Ekle",
                "button": {
                    "0": "Arama Oluşturucu",
                    "_": "Arama Oluşturucu (%d)"
                },
                "condition": "Koşul",
                "conditions": {
                    "date": {
                        "after": "Sonra",
                        "before": "Önce",
                        "between": "Arasında",
                        "empty": "Boş",
                        "equals": "Eşittir",
                        "not": "Değildir",
                        "notBetween": "Dışında",
                        "notEmpty": "Dolu"
                    },
                    "number": {
                        "between": "Arasında",
                        "empty": "Boş",
                        "equals": "Eşittir",
                        "gt": "Büyüktür",
                        "gte": "Büyük eşittir",
                        "lt": "Küçüktür",
                        "lte": "Küçük eşittir",
                        "not": "Değildir",
                        "notBetween": "Dışında",
                        "notEmpty": "Dolu"
                    },
                    "string": {
                        "contains": "İçerir",
                        "empty": "Boş",
                        "endsWith": "İle biter",
                        "equals": "Eşittir",
                        "not": "Değildir",
                        "notEmpty": "Dolu",
                        "startsWith": "İle başlar"
                    },
                    "array": {
                        "contains": "İçerir",
                        "empty": "Boş",
                        "equals": "Eşittir",
                        "not": "Değildir",
                        "notEmpty": "Dolu",
                        "without": "Hariç"
                    }
                },
                "data": "Veri",
                "deleteTitle": "Filtreleme kuralını silin",
                "leftTitle": "Kriteri dışarı çıkart",
                "logicAnd": "ve",
                "logicOr": "veya",
                "rightTitle": "Kriteri içeri al",
                "title": {
                    "0": "Arama Oluşturucu",
                    "_": "Arama Oluşturucu (%d)"
                },
                "value": "Değer",
                "clearAll": "Filtreleri Temizle"
            },
            "searchPanes": {
                "clearMessage": "Hepsini Temizle",
                "collapse": {
                    "0": "Arama Bölmesi",
                    "_": "Arama Bölmesi (%d)"
                },
                "count": "{total}",
                "countFiltered": "{shown}\/{total}",
                "emptyPanes": "Arama Bölmesi yok",
                "loadMessage": "Arama Bölmeleri yükleniyor ...",
                "title": "Etkin filtreler - %d"
            },
            "thousands": ".",
            "datetime": {
                "amPm": [
                    "öö",
                    "ös"
                ],
                "hours": "Saat",
                "minutes": "Dakika",
                "next": "Sonraki",
                "previous": "Önceki",
                "seconds": "Saniye",
                "unknown": "Bilinmeyen",
                "weekdays": {
                    "6": "Paz",
                    "5": "Cmt",
                    "4": "Cum",
                    "3": "Per",
                    "2": "Çar",
                    "1": "Sal",
                    "0": "Pzt"
                },
                "months": {
                    "9": "Ekim",
                    "8": "Eylül",
                    "7": "Ağustos",
                    "6": "Temmuz",
                    "5": "Haziran",
                    "4": "Mayıs",
                    "3": "Nisan",
                    "2": "Mart",
                    "11": "Aralık",
                    "10": "Kasım",
                    "1": "Şubat",
                    "0": "Ocak"
                }
            },
            "decimal": ",",
            "editor": {
                "close": "Kapat",
                "create": {
                    "button": "Yeni",
                    "submit": "Kaydet",
                    "title": "Yeni kayıt oluştur"
                },
                "edit": {
                    "button": "Düzenle",
                    "submit": "Güncelle",
                    "title": "Kaydı düzenle"
                },
                "error": {
                    "system": "Bir sistem hatası oluştu (Ayrıntılı bilgi)"
                },
                "multi": {
                    "info": "Seçili kayıtlar bu alanda farklı değerler içeriyor. Seçili kayıtların hepsinde bu alana aynı değeri atamak için buraya tıklayın; aksi halde her kayıt bu alanda kendi değerini koruyacak.",
                    "noMulti": "Bu alan bir grup olarak değil ancak tekil olarak düzenlenebilir.",
                    "restore": "Değişiklikleri geri al",
                    "title": "Çoklu değer"
                },
                "remove": {
                    "button": "Sil",
                    "confirm": {
                        "_": "%d adet kaydı silmek istediğinize emin misiniz?",
                        "1": "Bu kaydı silmek istediğinizden emin misiniz?"
                    },
                    "submit": "Sil",
                    "title": "Kayıtları sil"
                }
            }
        }
    });
    /* DataTabels end here */

    // Ajax Get / Getting the _VisitorAddPartial as Modal Form starts from here..
    $(function () {
        const url = '/Admin/Visitor/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () { /*VisitorPartialView alıp geliyor actiondan--data categoryAddPartialView*/
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });

        });


        //Ajax Get / Getting the _VisitorAddPartial as Modal Form ends  here..
        // Ajax Post / Posting the FormData as VisitorAddDto starts from here...
        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                event.preventDefault();

                const form = $('#form-visitor-add');
                const actionUrl = form.attr('action');
                const dataToSend = new FormData(form.get(0));
                $.ajax({
                    url: actionUrl,
                    type: 'POST',
                    data: dataToSend,
                    processData: false,
                    contentType: false,
                    success: function (re) {
                        console.log(re);
                        const visitorAddAjaxModel = jQuery.parseJSON(re);
                        console.log(visitorAddAjaxModel);
                        const newFormBody = $('.modal-body', visitorAddAjaxModel.VisitorAddPartial);
                        placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                        const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            placeHolderDiv.find('.modal').modal('hide');
                            const newTableRow = dataTable.row.add([
                                visitorAddAjaxModel.VisitorDto.Visitor.TcNo,
                                visitorAddAjaxModel.VisitorDto.Visitor.FirstName,
                                visitorAddAjaxModel.VisitorDto.Visitor.LastName,
                                moment(visitorAddAjaxModel.VisitorDto.Visitor.BirthDate).format('DD-MM-YYYY'),
                                visitorAddAjaxModel.VisitorDto.Visitor.ContactNo,
                                moment(visitorAddAjaxModel.VisitorDto.Visitor.EnterDate).format('DD-MM-YYYY HH:mm'),
                                moment(visitorAddAjaxModel.VisitorDto.Visitor.OutDate).format('DD-MM-YYYY HH:mm'),
                                visitorAddAjaxModel.VisitorDto.Visitor.Department.Name,
                                `
                                    <button class="btn btn-primary btn-sm btn-block btn-exit"    data-id="${visitorAddAjaxModel.VisitorDto.Visitor.Id}"><span class="fas fa-sign-in-alt" style="background-color:blue; border-color:blue "></span></button>
                                    <button class="btn btn-danger  btn-sm btn-block btn-delete"  data-id="${visitorAddAjaxModel.VisitorDto.Visitor.Id}"><span class="fas fa-minus-circle"></span></button>
                                    `
                            ]).node();
                            const jqueryTableRow = $(newTableRow);
                            jqueryTableRow.attr('name', `${visitorAddAjaxModel.VisitorDto.Visitor.Id}`);
                            dataTable.row(newTableRow).draw();
                            toastr.success(`${visitorAddAjaxModel.VisitorDto.Message}`, 'Başarılı İşlem!');


                        } else {
                            let summaryText = "";
                            $('#validation-summary > ul > li').each(function () {
                                let text = $(this).text();
                                summaryText = `*${text}\n`;
                            });
                            toastr.warning(summaryText);
                        }
                    }, error: function (err) {
                        console.log(err);
                        toastr.error(`${err.responseText}`, "Hata!")
                    }
                });

            });




        //Ajax Post / Posting the formData as UserAddDto ends here 
        /* Ajax Post / Deleting a Visitor starts from here */

        $(document).on('click',
            '.btn-delete',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                const tableRow = $(`[name="${id}"]`);
                const vistorName = tableRow.find('td:eq(1)').text();
                Swal.fire({
                    title: 'Silmek istediğinize emin misiniz?',
                    text: `${vistorName} adlı ziyaretçi silinicektir!`,
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
                            data: { visitorId: id },
                            url: '/Admin/Visitor/Delete/',
                            success: function (data) {
                                const visitorDto = jQuery.parseJSON(data);
                                if (visitorDto.ResultStatus === 0) {
                                    Swal.fire(
                                        'Silindi!',
                                        `${visitorDto.Visitor.FirstName} adlı ziyaretçi başarıyla silinmiştir.`,
                                        'success'
                                    );
                                    dataTable.row(tableRow).remove().draw();

                                } else {
                                    Swal.fire({
                                        icon: 'error',
                                        title: 'Başarısız İşlem!',
                                        text: `${visitorDto.Message}`,
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

        /* Ajax Post / IsExit a Visitor starts from here */

        $(document).on('click',
            '.btn-exit',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('data-id');
                const tableRow = $(`[name="${id}"]`);
                const vistorName = tableRow.find('td:eq(1)').text();
                Swal.fire({
                    title: 'Çıkış yapmak istediğinize emin misiniz?',
                    text: `${vistorName} adlı ziyaretçi çıkış yapılacaktır!`,
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Evet, çıkış yapmak istiyorum.',
                    cancelButtonText: 'Hayır, çıkış yapmak istemiyorum.'
                }).then((result) => {
                    if (result.isConfirmed) {
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            data: { visitorId: id },
                            url: '/Admin/Visitor/IsExit/',
                            success: function (data) {
                                const visitorDto = jQuery.parseJSON(data);
                                console.log(visitorDto);
                                const id = visitorDto.Visitor.Id;
                                const tableRow = $(`[name="${id}"]`);
                                if (visitorDto.ResultStatus === 0) {
                                    Swal.fire(
                                        'Çıkış Yapıldı!',
                                        `${visitorDto.Visitor.FirstName} adlı ziyaretçi başarıyla çıkış yaptı.`,
                                        'success'
                                    );
                                    dataTable.row(tableRow).data([
                                        visitorDto.Visitor.TcNo,
                                        visitorDto.Visitor.FirstName,
                                        visitorDto.Visitor.LastName,
                                        moment(visitorDto.Visitor.BirthDate).format('DD-MM-YYYY'),
                                        visitorDto.Visitor.ContactNo,
                                        moment(visitorDto.Visitor.EnterDate).format('DD-MM-YYYY HH:mm'),
                                        moment(visitorDto.Visitor.OutDate).format('DD-MM-YYYY HH:mm'),
                                        visitorDto.Visitor.Department.Name,

                                        `
                                <button class="btn btn-primary btn-block btn-sm btn-exit"   data-id="${visitorDto.Visitor.Id}" style="background-color:blue; border-color:blue "><span class="fas fa-sign-in-alt" ></span></button>
                                <button class="btn btn-danger  btn-block btn-sm btn-delete" data-id="${visitorDto.Visitor.Id}"><span class="fas fa-minus-circle"></span></button>
                            `
                                    ]);
                                    tableRow.attr("name", `${id}`);
                                    dataTable.row(tableRow).invalidate();



                                } else {
                                    Swal.fire({
                                        icon: 'error',
                                        title: 'Başarısız İşlem!',
                                        text: `${visitorDto.Message}`,
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




    });

});