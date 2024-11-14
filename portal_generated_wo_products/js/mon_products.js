infrastructureGroupSelect = document.getElementById("infrastructureGroup");
infrastructureSelect = document.getElementById("infrastructure");

titleElement = document.getElementById("product_title");
descriptionElement = document.getElementById("product_description");
imageDivElement = document.getElementById("product_image_div");
iframeDivElement = document.getElementById("product_iframe_div");
imageElement = document.getElementById("product_image"); 
iframeElement = document.getElementById("product_iframe");
downloadElement = document.getElementById("product_download");
openElement = document.getElementById("product_open");


var isChrome = navigator.userAgent.includes("Chrome") && navigator.vendor.includes("Google Inc");
if (isChrome) {
    iframeWarning = document.getElementById("iframe_warning");
    iframeWarning.classList.toggle("hidden", true);
}

function updateURL() {
    const group = infrastructureGroupSelect.value;
    const infra = infrastructureSelect.value;
    const newURL = `${window.location.pathname}?group=${group}&infra=${infra}`;
    window.history.replaceState(null, '', newURL);
}

// Function to initialize dropdowns based on URL query parameters
function initFromURL() {
    const urlParams = new URLSearchParams(window.location.search);
    const group = urlParams.get('group');
    const infra = urlParams.get('infra');

    if (!group || !infra) {
        infrastructureGroupSelect.value = "rural_development";
        infrastructureGroupSelect.dispatchEvent(new Event('change'));
        return;
    }
    
    if (group) {
        infrastructureGroupSelect.value = group;
        infrastructureGroupSelect.dispatchEvent(new Event('change'));
    }

    if (infra) {
        infrastructureSelect.value = infra;
        infrastructureSelect.dispatchEvent(new Event('change'));
    }
}

function selectInfrastructureGroup(value) {
    infrastructureGroupSelect.value = value;
    
    var first = false;
    const options = infrastructureSelect.options;
    for (var i = options.length - 1; i >= 0; i--) {
        option = options[i]
        now_on = !option.classList.contains(value)
        option.classList.toggle('hidden', now_on);
        
        if (!first && !now_on) {
            first = false
            selectInfrastructure(option.value)
        }
    }

    infrastructureSelect.dispatchEvent(new Event('change'));
}

function selectInfrastructure(value) {
    infrastructureSelect.value = value;

    fetch('../products/MON/' + value + ".json")
        .then((response) => response.json())
        .then((json) => {
            if (json.Id != infrastructureSelect.value)
                return

            descriptionElement.innerHTML = json.Description;
            titleElement.innerHTML = "<i class=\"" + json.Icon +"\"></i> " + json.Title;
            
            if (json.Iframe === "") {
                iframeDivElement.classList.add("hidden");
                imageElement.src = json.Image;
                imageDivElement.classList.remove("hidden");
                downloadElement.href = json.Image;
                openElement.href = json.Image;
            }
            else {
                imageDivElement.classList.add("hidden");
                iframeElement.src = json.Iframe;
                iframeDivElement.classList.remove("hidden");
                downloadElement.href = json.Iframe;
                openElement.href = json.Iframe;
            }
        });
}

infrastructureGroupSelect.addEventListener('change', function () {
    selectInfrastructureGroup(this.value);
});

infrastructureSelect.addEventListener('change', function () {
    selectInfrastructure(this.value);
    updateURL();
});

initFromURL()