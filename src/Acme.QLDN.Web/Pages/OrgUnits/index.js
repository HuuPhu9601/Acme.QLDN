$(function () {
    debugger
    var l = abp.localization.getResource('QLDN');

    var dataTable = $('#BooksTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.qldn.orgUnits.orgUnit.getList),
            columnDefs: [
                {
                    title: l('OrgUnitName'),
                    data: "name"
                },
                {
                    title: l('MaxQty'),
                    data: "maxQty",
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );
});
