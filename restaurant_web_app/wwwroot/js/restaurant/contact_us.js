



function buildForm() {

    var formData = {
            name: "",
            email: "",
            subject: "",
            message: ""
        };
    

    var formConfig = {};
    formConfig.formData = formData;
    formConfig.showValidationSummary = true;
    formConfig.colCount = 2;
    formConfig.items = [
        {
            itemType: "group",
            items: [
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
                    dataField: "emailAddress",
                    editorType: "dxTextBox",
                    validationRules: [{
                        type: "required",
                        message: "Email is required"
                    }]
                },
                {
                    dataField: "subject",
                    editorType: "dxTextBox",
                    validationRules: [{
                        type: "required",
                        message: "Subject is required"
                    }]
                },
            ]
        },
        {
            itemType: "group",
            name:"booking-info",
            items: [
                {
                    dataField: "message",
                    editorType: "dxTextArea",
                    validationRules: [
                        {
                            type: "required",
                            message: "Message is required"
                        }
                    ],
                    editorOptions: {

                        height: 200,
                    }
                }
            ]
        },
        {
            itemType: "button",
            horizontalAlignment: "Right",
            buttonOptions: {
                text: "Send",
                type: "success",
                useSubmitBehavior: true,

            }
        }
    ];

    window.formWidget = $("#mainForm").dxForm(formConfig).dxForm("instance");
}
