



function buildForm(partySizeArray, disabledDatesArray, bookingStatusArray, getAvailableSchedulingUrl) {
    //var modelData = model;
    //var array = timesArray;
    var modelData = null;

    var disabledDatesJsArray = disabledDatesArray.map(e => {
        var date = new Date(Date.parse(e));

        //return new Date(0, date.getMonth(), date.getDay());
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

    //var availableSchedulingBookingDataSource = new DevExpress.data.DataSource(getAvailableSchedulingUrl);
    var availableSchedulingBookingStore = new DevExpress.data.CustomStore({
        load: function (loadOptions) {
            return $.getJSON(getAvailableSchedulingUrl);
        },
        byKey: function (key) {
            //return $.getJSON(getAvailableSchedulingUrl + "/" + encodeURIComponent(key));
            var queryParams = new URLSearchParams(key).toString();

            var url = updateQueryStringParameter(getAvailableSchedulingUrl, "date", key);
            return $.getJSON(url);
        },
    });

    var availableSchedulingBookingDataSource = new DevExpress.data.DataSource({
        store: availableSchedulingBookingStore
    });

    var formData = {};

    if (modelData) {
        formData = {
            id: modelData.Id,
            name: modelData.Name,
            email: modelData.Email,
            Date: modelData.Date,
            phone: modelData.Phone,
            status: modelData.Status,
            detail: modelData.Detail,
            partySize: modelData.PartySize

        };
    } else {
        formData = {
            id: 0,
            name: "",
            email: "",
            Date: null,
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
                        displayExpr: "Value",
                        valueExpr: "Key"
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
                        displayExpr: "Value",
                        valueExpr: "Key"
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
                        calendarOptions: {
                            min: new Date(),
                        },
                        disabledDates: disabledDatesJsArray,
                        onValueChanged: function (e) {
                            var dataSource = formWidget.itemOption("booking-info.timeId").editorOptions.dataSource;
                            dataSource.store().byKey(e.value.getTime());
                            dataSource.load();
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
                        dataSource: availableSchedulingBookingDataSource
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