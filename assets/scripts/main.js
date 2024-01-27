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
    campos.forEach(function(item){ 
        const teclasAceitas = [48,49,50,51,52,53,54,55,56,57,99,98,97,96,99,100,101,102,103,104,105]
        item.addEventListener('keyup', function(e){
            console.log(e.keyCode)
            if (!teclasAceitas.includes(e.keyCode)) {
                item.value = "";
            }
        })
    })
}

function carregarCategoria(){
    const elementCategoria =  document.getElementById("categoriaMotivo")
    categorias.forEach(function (objCat){
        let opt = document.createElement('option');
        opt.text = objCat.Descricao;
        opt.value = objCat.idCategoria;
        elementCategoria.appendChild(opt);
        console.log(objCat);
    })

}

function carregarMotivoAoAlterarCategoria(){
    const elementCategoria =  document.getElementById("categoriaMotivo")
    elementCategoria.addEventListener("change",function(){
        let valorEscolhido = elementCategoria.value;
        const motivosFiltrados =
        motivos.filter((obj) => obj.idCategoria==valorEscolhido)

        const elementMotivo =  document.getElementById("Motivo")
        elementMotivo.innerHTML ="";
        motivosFiltrados.forEach(function(item){
      
                let opt = document.createElement('option');
                opt.text = item.Descricao;
                opt.value = item.idMotivo;
                elementMotivo.appendChild(opt);

        
        })
    })
}

function carregarNomesDepartamentoAoAlterarIDDepartamento(){
const elementIdDep = document.getElementById("idDepartamento")
elementIdDep.addEventListener("keyup",function(){
    const valorPesquisar = elementIdDep.value;
    const departamentoEncontrado = 
    departamentos.find((dep)=>dep.Codigo==valorPesquisar)

    if (departamentoEncontrado!=undefined) {
        document.getElementById("departamento").value=
        departamentoEncontrado.Descricao;
    }else{
        document.getElementById("departamento").value=""
    }

})
}

function carregarNomesFuncionarioAoAlterarIDDepartamento(){
    const elementIdFunc = document.getElementById("idFuncionario")
    elementIdFunc.addEventListener("keyup",function(){
        const valorPesquisar = elementIdFunc.value;
        const funcionarioEncontrado = 
        funcionario.find((func)=>func.idFunc==valorPesquisar)
    
        if (funcionarioEncontrado!=undefined) {
            document.getElementById("NomeFuncionario").value=
            funcionarioEncontrado.Responsavel;
            document.getElementById("cargo").value=
            funcionarioEncontrado.idCargo;
        }else{
            document.getElementById("NomeFuncionario").value=""
            document.getElementById("cargo").value=""
            
        }
    
    })
    }

carregarNomesFuncionarioAoAlterarIDDepartamento()
carregarNomesDepartamentoAoAlterarIDDepartamento()
carregarMotivoAoAlterarCategoria()
carregarCategoria()
adicionarCamposAceitarSomenteInteiro()

