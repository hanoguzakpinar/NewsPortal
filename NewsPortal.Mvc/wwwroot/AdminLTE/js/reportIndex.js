$(document).ready(function () {

    /* DataTables start here. */

    const dataTable = $('#reportsTable').DataTable({
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
                        url: '/Admin/Report/GetAllReports/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#reportsTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const reportResult = jQuery.parseJSON(data);
                            dataTable.clear();
                            console.log(reportResult);
                            if (reportResult.Data.ResultStatus === 0) {
                                let categoriesArray = [];
                                $.each(reportResult.Data.Reports.$values,
                                    function (index, report) {
                                        const newReport = getJsonNetObject(report, reportResult.Data.Reports.$values);
                                        let newCategory = getJsonNetObject(newReport.Category, newReport);
                                        if (newCategory !== null) {
                                            categoriesArray.push(newCategory);
                                        }
                                        if (newCategory === null) {
                                            newCategory = categoriesArray.find(category => {
                                                return category.$id === newReport.Category.$ref;
                                            })
                                        }
                                        console.log(newReport);
                                        console.log(newCategory);
                                        const newTableRow = dataTable.row.add([
                                            newReport.Id,
                                            newCategory.Name,
                                            newReport.Title,
                                            `<img src="/img/${newReport.Thumbnail}" alt="${newReport.Title}" class="my-image-table" />`,
                                            `${convertToShortDate(newReport.Date)}`,
                                            //newReport.ViewsCount,
                                            //newReport.CommentCount,
                                            `${newReport.IsActive ? "Evet" : "Hayır"}`,
                                            `${newReport.IsDeleted ? "Evet" : "Hayır"}`,
                                            `${convertToShortDate(newReport.CreatedDate)}`,
                                            newReport.CreatedByName,
                                            `${convertToShortDate(newReport.ModifiedDate)}`,
                                            newReport.ModifiedByName,
                                            `
                                <a class="btn btn-primary btn-sm btn-update" href="/Admin/Report/Update?reportId=${newReport.Id}"><span class="fa fa-edit"></span></a>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${newReport.Id}"><span class="fa fa-minus-circle"></span></button>
                                            `
                                        ]).node();
                                        const jqueryTableRow = $(newTableRow);
                                        jqueryTableRow.attr('name', `${newReport.Id}`);
                                    });
                                dataTable.draw();
                                $('.spinner-border').hide();
                                $('#reportsTable').fadeIn(1400);
                            } else {
                                toastr.error(`${reportResult.Data.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#reportsTable').fadeIn(1000);
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
            "sSearch": "Ara",
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

    /* Ajax POST / Deleting a User starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const reportTitle = tableRow.find('td:eq(2)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${reportTitle} adlı haber silinicektir!`,
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
                        data: { reportId: id },
                        url: '/Admin/Report/Delete/',
                        success: function (data) {
                            const reportResult = jQuery.parseJSON(data);
                            if (reportResult.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${reportResult.Message}`,
                                    'success'
                                );

                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${reportResult.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Hata!");
                        }
                    });
                }
            });
        });
});