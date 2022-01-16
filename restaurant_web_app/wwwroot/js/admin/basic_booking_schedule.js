



function buildForm(model , timesArray) {
    var modelData = model;
    var array = timesArray;

    var dataSource = new DevExpress.data.DataSource({
        store: {
            key: "key",
            data: array,
            type: "array",
        }
    });

    var formData = {};

    if (modelData) {
        formData = {
            id: modelData.Id,
            mondaySelected: modelData.MondaySelected,
            tuesdaySelected: modelData.TuesdaySelected,
            wednesdaySelected: modelData.WednesdaySelected,
            thursdaySelected: modelData.ThursdaySelected,
            fridaySelected: modelData.FridaySelected,
            saturdaySelected: modelData.SaturdaySelected,
            sundaySelected: modelData.SundaySelected,
            startTimeId: modelData.StartTimeId,
            endTimeId: modelData.EndTimeId
        };
    } else {
        formData = {
            id:0,
            mondaySelected: false,
            tuesdaySelected: false,
            wednesdaySelected: false,
            thursdaySelected: false,
            fridaySelected: false,
            saturdaySelected: false,
            sundaySelected: false
        };
    }

    var formConfig = {};
    formConfig.formData = formData;
    formConfig.showValidationSummary = true;
    formConfig.colCount = 2;
    formConfig.items = [
        {
            itemType: "group",
            caption: "Days of the week",
            items: [
                {
                    dataField: "id",
                    editorOptions: {
                        visible:false
                    },
                    label: {
                        visible:false
                    }
                },
                {
                    dataField: "mondaySelected",
                    editorType: "dxCheckBox",
                    validationRules: [
                        {
                            type: "custom",
                            message: "Select at least one day",
                            reevaluate: true,
                            validationCallback: function(e) {
                                return e.value || areWeekDaysValid();
                            }
                        }
                    ]
                },
                {
                    dataField: "tuesdaySelected",
                    editorType: "dxCheckBox"
                },
                {
                    dataField: "wednesdaySelected",
                    editorType: "dxCheckBox"
                },
                {
                    dataField: "thursdaySelected",
                    editorType: "dxCheckBox"
                },
                {
                    dataField: "fridaySelected",
                    editorType: "dxCheckBox"
                },
                {
                    dataField: "saturdaySelected",
                    editorType: "dxCheckBox"
                },
                {
                    dataField: "sundaySelected",
                    editorType: "dxCheckBox"
                }
            ]
        },
        {
            itemType: "group",
            caption: "Select time range",
            items: [
                {
                    dataField: "startTimeId",
                    editorType: "dxSelectBox",
                    editorOptions: {
                        dataSource: dataSource,
                        displayExpr: "value",
                        valueExpr: "key"
                    },
                    validationRules: [
                        {
                            type: "required",
                            message: "Start time is required"
                        },
                        {
                            type: "custom",
                            message: "Start time must be less end time.",
                            reevaluate: true,
                            validationCallback: function(e) {

                                var endTime = parseInt(formWidget.option("formData").endTimeId);
                                var startTime = parseInt(formWidget.option("formData").startTimeId);

                                if (startTime >= endTime) {
                                    return false;
                                }
                                return true;
                            }
                        }
                    ],
                }, {
                    dataField: "endTimeId",
                    editorType: "dxSelectBox",
                    validationRules: [
                        {
                            type: "required",
                            message: "End time is required"
                        },
                        {
                            type: "custom",
                            message: "End time must be greater than start time.",
                            reevaluate: true,
                            validationCallback: function(e) {

                                var endTime = parseInt(formWidget.option("formData").endTimeId);
                                var startTime = parseInt(formWidget.option("formData").startTimeId);

                                if (startTime >= endTime) {
                                    return false;
                                }
                                return true;
                            }
                        }
                    ],

                    editorOptions: {
                        dataSource: dataSource,
                        displayExpr: "value",
                        valueExpr: "key"
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

function areWeekDaysValid() {

    var friday = formWidget.option("formData").fridaySelected;
    var monday = formWidget.option("formData").mondaySelected;
    var saturday = formWidget.option("formData").saturdaySelected;
    var sunday = formWidget.option("formData").sundaySelected;
    var thursday = formWidget.option("formData").thursdaySelected;
    var tuesday = formWidget.option("formData").tuesdaySelected;
    var wednesday = formWidget.option("formData").wednesdaySelected;

    var isValid = monday || tuesday || wednesday || thursday || friday || saturday || sunday;

    if (isValid) {
        return true;
    }

    return false;
}