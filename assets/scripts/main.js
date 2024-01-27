const buttonClick = document.getElementById("btnGravar")
const inputs = document.querySelectorAll('input,select');

 
buttonClick.addEventListener("click",function(){
    console.log("Clicou em gravar")
    const valorIdDepartamento = document.getElementById("idDepartamento");
    const valorNomeDep = document.getElementById("departamento");
    const valorData = document.getElementById("dataRequisicao");

    const campos = document.querySelectorAll('[data-obrigatorio="true"]')
 

    campos.forEach(function(itemElemento){
        if (itemElemento.value == "") {
            itemElemento.style.backgroundColor = "red";
            temCampoVazio=true;
        }
        else{
            itemElemento.style.backgroundColor = "#ffffff";
        }
    
    })

    if (temCampoVazio) {
        return
    }
        console.log("Final de Gravar")
})


inputs.forEach(function(itemElemento){
  itemElemento.addEventListener("focus", () => {
    itemElemento.style.backgroundColor = "green";
})

itemElemento.addEventListener("blur", () => {
    itemElemento.style.backgroundColor = "";
})


})


function adicionarCamposAceitarSomenteInteiro(){
    const campos = document.querySelectorAll('[data-soInteiroPositivo="true"]')
    campos.forEach(function(item){ console.log(item)
        item.addEventListener('keyup', function(e){
            console.log(e)
            console.log(e.keyCode<96 || e.keyCode>106)
            if (e.keyCode<96 || e.keyCode>106) {
                item.value = "";
            }
        })
    })
}

adicionarCamposAceitarSomenteInteiro()