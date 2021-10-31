



function buildForm() {



    var formData = {};
    
    var formConfig = {};
    formConfig.formData = formData;
    formConfig.showValidationSummary = true;
    formConfig.colCount = 1;
    
    formConfig.items = [
        {
            dataField: "date",
            editorType: "dxDateBox",
            validationRules: [
                {
                    type: "required",
                    message: "Time is required"
                }
            ],

            editorOptions: {
                calendarOptions: {
                    min: new Date(),
                }
            }
        },
        {
            itemType: "button",
            horizontalAlignment: "Right",
            buttonOptions: {
                text: "Save",
                type: "success",
                useSubmitBehavior: true
                
            }
        }
    ];

    window.formWidget = $("#mainForm").dxForm(formConfig).dxForm("instance");
}
