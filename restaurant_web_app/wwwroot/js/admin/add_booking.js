



function buildForm(partySizeArray, disabledDatesArray, bookingStatusArray, getAvailableSchedulingUrl, modelData, availableTimesArray) {

    var disabledDatesJsArray = disabledDatesArray.map(e => {
        var date = new Date(Date.parse(e));
        return date;
    });


    var dataSourcePartySize = new DevExpress.data.DataSource({
        store: {
            key: "Key",
            data: partySizeArray,
            type: "array"
        }
    });

    var dataSourceBookingStatus = new DevExpress.data.DataSource({
        store: {
            key: "Key",
            data: bookingStatusArray,
            type: "array"
        }
    });

    var availableTimes = [];
    if (availableTimesArray) {
        availableTimes = availableTimesArray;
    }
    var availableSchedulingBookingStore = new DevExpress.data.DataSource({
        store: {
            key: "Key",
            data: availableTimes,
            type: "array"
        }
    });

    var formData = {};

    if (modelData) {
        formData = {
            id: modelData.Id,
            name: modelData.Name,
            email: modelData.Email,
            date: modelData.DateString,
            phone: modelData.Phone,
            status: modelData.Status,
            detail: modelData.Detail,
            partySize: modelData.PartySize,
            timeId: modelData.TimeId
    };
    } else {
        formData = {
            id: 0,
            name: "",
            email: "",
            date: "",
            phone: "",
            status: 0,
            detail: "",
            partySize : null
        };
    }

    var formConfig = {};
    formConfig.formData = formData;
    formConfig.showValidationSummary = true;
    formConfig.colCount = 2;
    formConfig.items = [
        {
            itemType: "group",
            caption: "Personal Information",
            items: [
                {
                    dataField: "id",
                    editorOptions: {
                        visible: false
                    },
                    label: {
                        visible: false
                    }
                },
                {
                    dataField: "name",
                    editorType: "dxTextBox",
                    validationRules: [
                        {
                            type: "required",
                            message: "Name is required"
                        }
                    ]
                },
                {
                    dataField: "email",
                    editorType: "dxTextBox",
                    validationRules: [{
                        type: "required",
                        message: "Email is required"
                    }, {
                        type: "email",
                        message: "Email is invalid"
                    }]
                },
                {
                    dataField: "phone",
                    editorType: "dxTextBox",
                    validationRules: [{
                        type: "required",
                        message: "Phone is required"
                    }]
                },
                {
                    dataField: "Detail",
                    editorType: "dxTextArea",
                    validationRules: [{
                        type: "required",
                        message: "Phone is required"
                    }],
                    editorOptions: {
                        height: 90
                    }
                }
            ]
        },
        {
            itemType: "group",
            caption: "Booking information",
            name:"booking-info",
            items: [
                {
                    dataField: "partySize",
                    editorType: "dxSelectBox",
                    editorOptions: {
                        dataSource: dataSourcePartySize,
                        displayExpr: "value",
                        valueExpr: "key"
                    },
                    validationRules: [
                        {
                            type: "required",
                            message: "Party Size is required"
                        }
                    ]
                },
                {
                    dataField: "status",
                    editorType: "dxSelectBox",
                    validationRules: [
                        {
                            type: "required",
                            message: "Status is required"
                        }
                    ],

                    editorOptions: {
                        dataSource: dataSourceBookingStatus,
                        displayExpr: "value",
                        valueExpr: "key"
                    }
                },
                {
                    dataField: "date",
                    editorType: "dxDateBox",
                    validationRules: [
                        {
                            type: "required",
                            message: "Date is required"
                        }
                    ],

                    editorOptions: {
                        type:"date",
                        calendarOptions: {
                            min: new Date(),
                        },
                        disabledDates: disabledDatesJsArray,
                        onValueChanged: function (e) {
                            //var dateInMilliseconds = e.value.getTime();
                            var dateString = e.value;

                            if (e.value instanceof Date) {
                                var year = e.value.getFullYear();
                                var month = e.value.getMonth() + 1;
                                var day = e.value.getDate();

                                dateString = `${year}-${month}-${day}`;
                            }
                            //var dateString = e.value;
                            var url = updateQueryStringParameter(getAvailableSchedulingUrl, "date", dateString);
                            var result = $.getJSON(url, function (data) {
                                var dataSource = formWidget.itemOption("booking-info.timeId").editorOptions.dataSource;
                                var store = dataSource.store();
                                store.clear();
                                data.forEach((e) => {
                                    store.insert(e);
                                });
                                dataSource.reload();
                            });
                        }
                    }
                },
                {
                    dataField: "timeId",
                    editorType: "dxSelectBox",
                    label: {
                        text :  "Time"
                    },
                    validationRules: [
                        {
                            type: "required",
                            message: "Status is required"
                        }
                    ],

                    editorOptions: {

                        displayExpr: "value",
                        valueExpr: "key",
                        dataSource: availableSchedulingBookingStore
                    }
                }
            ]
        },
        {
            itemType: "button",
            horizontalAlignment: "Right",
            buttonOptions: {
                text: "Save",
                type: "success",
                useSubmitBehavior: true,

            }
        }
    ];

    window.formWidget = $("#mainForm").dxForm(formConfig).dxForm("instance");
}

function updateQueryStringParameter(uri, key, value) {
    var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
    var separator = uri.indexOf('?') !== -1 ? "&" : "?";
    if (uri.match(re)) {
        return uri.replace(re, '$1' + key + "=" + value + '$2');
    }
    else {
        return uri + separator + key + "=" + value;
    }
}