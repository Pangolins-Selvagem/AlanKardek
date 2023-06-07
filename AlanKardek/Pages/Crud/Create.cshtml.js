const form = document.querySelector("form");
nField = form.querySelector(".nome");
nInput = nField.querySelector("input");
sField = form.querySelector(".senha");
sInput = sField.querySelector("input");
eField = form.querySelector(".email");
eInput = eField.querySelector("input");
tiField = form.querySelector(".tipo");
tiInput = tiField.querySelector("input");
tuField = form.querySelector(".turma");
tuInput = tuField.querySelector("input");
pField = form.querySelector(".privilegiado");
pInput = pField.querySelector("input");


function tipo() {
    if (tiInput.value == "U" || tiInput.value == "P") {
        pInput.value = "N";
        pField.hidden = true;
        pInput.disabled = true;
        let tu = tuInput.value.length
        if (tu === 0 || tu === 1) {
            tuInput.value += 'T'
        }
    } else {
        pField.hidden = false;
        pInput.disabled = false;
    }
    if (tiInput.value == "A" || tiInput.value == "P") {
        tuInput.value = 0;
        tuField.hidden = true;
        tuInput.disabled = true;
    } else {
        tuField.hidden = false;
        tuInput.disabled = false;
    }
}