



function buildForm(modelData) {

    var formData = {
            name: "",
            description: "",
            price: "",
            isNew: true
        };
    

    var formConfig = {};
    if (modelData) {
        formData.id = modelData.Id;
        formData.name = modelData.Name;
        formData.description = modelData.Description;
        formData.price = modelData.Price;
        formData.priceSymbol = modelData.PriceSymbol;
        formData.isNew = modelData.IsNew;
        $("#productImageBase64").val(modelData.ProductImageBase64);
    }

    formConfig.formData = formData;
    formConfig.showValidationSummary = true;
    formConfig.colCount = 1;


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
                    dataField: "description",
                    editorType: "dxTextBox",
                    validationRules: [{
                        type: "required",
                        message: "description is required"
                    }]
                },
                
                {
                    dataField: "price",
                    editorType: "dxTextBox",
                    validationRules: [{
                        type: "required",
                        message: "Subject is required"
                    }]
                },
                {
                    dataField: "priceSymbol",
                    editorType: "dxTextBox",
                    validationRules: [{
                        type: "required",
                        message: "price Symbol is required"
                    }]
                },
                {
                    dataField: "isNew",
                    editorType: "dxCheckBox",
                },
            {
            itemType: "group",
            name: "image-info",
            items: [
                {
                    dataField: "productImageBase642",
                    editorType: "dxFileUploader",
                    label: {
                        text: "Product Image(370x420)"
                    },
                    validationRules: [{
                        type: "required",
                        message: "image is required"
                    }],
                    editorOptions: {
                        selectButtonText: "Select Image",
                        accept: 'image/*',
                        uploadMode: 'useForm',
                        onValueChanged: function(e) {
                            console.log("valuechanged");
                            getBase64(e.value[0]);
                        },
                        maxFileSize: 3000000
                    }
                },
                //{
                //    dataField: "productImageBase64",
                //    visible:true
                //}
            ]
        },
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

function getBase64(file) {

    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
        console.log(reader.result);
        //window.formWidget.updateData("productImageBase64", reader.result);
        $("#productImageBase64").val(reader.result);
    };
    reader.onerror = function (error) {
        console.log('Error: ', error);
    };
}
