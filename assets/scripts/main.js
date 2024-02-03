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


    function carregarProdutoPorID(){
    const  elementIdProd = document.getElementById("CodigoProduto");
    elementIdProd.addEventListener("keyup",function(){
        const valorPesquisar = elementIdProd.value
        const produtoEncontrado =
        produtos.find((obj)=>obj.idProduto==valorPesquisar);

        if (produtoEncontrado!=undefined) {
            document.getElementById("DescricaoProduto").value =
            produtoEncontrado.Descricao
            document.getElementById("Estoque").value =
            produtoEncontrado.Estoque
            let cor = verificarRegraPercentualEstoqueMinimo(produtoEncontrado);
            const elementoImg = document.getElementById("imgStatus")
            if (cor=="verde") {
                console.log(elementoImg)
                elementoImg.src = "/assets/img/verde.png"
            }else if(cor =="vermelho"){
                elementoImg.src = "/assets/img/vermelho.png"
            }else{
                elementoImg.src = "/assets/img/amarelo.png"
            }
        }else{
            document.getElementById("DescricaoProduto").value =""
            document.getElementById("Estoque").value =""
        }
    })
    }

function verificarRegraPercentualEstoqueMinimo(pProduto){
    let vPerc10 = Math.round(pProduto.EstoqueMinimo*10/100) + pProduto.EstoqueMinimo
    console.log(vPerc10)

    if (pProduto.Estoque>vPerc10) {
        return "verde"
    } else if(pProduto.Estoque<pProduto.EstoqueMinimo){
        return "vermelho"
    }else{
        return "amarelo"
    }
}


document.getElementById("BtnInserirItens").addEventListener('click',function(){
    const tabelaItens = document.getElementById("tabelaItens")
    var total = document.getElementById("total") 
    let codigoProduto = document.getElementById("CodigoProduto").value
    let quantidade = document.getElementById("Quantidade").value
    const produtoEncontrado =
          produtos.find((obj)=> obj.idProduto==codigoProduto)

    const linha = document.createElement("tr")

    const tdCodigo = document.createElement("td");
    const tdDescricao = document.createElement("td");
    const tdQuantidade = document.createElement("td");
    const tdUnidade = document.createElement("td");
    const tdPreco = document.createElement("td");
    const tdTotal = document.createElement("td");

    tdCodigo.innerHTML = codigoProduto;
    tdDescricao.innerHTML = produtoEncontrado.Descricao;
    tdQuantidade.innerHTML = quantidade;
    tdUnidade.innerHTML = produtoEncontrado.Unidade;
    tdPreco.innerHTML = produtoEncontrado.Preco;
    tdTotal.innerHTML = produtoEncontrado.Preco*quantidade;
    total.value += produtoEncontrado.Preco*quantidade;

    linha.appendChild(tdCodigo);
    linha.appendChild(tdDescricao);
    linha.appendChild(tdQuantidade);
    linha.appendChild(tdUnidade);
    linha.appendChild(tdPreco);
    linha.appendChild(tdTotal);

    tabelaItens.appendChild(linha);
})

carregarProdutoPorID()
carregarNomesFuncionarioAoAlterarIDDepartamento()
carregarNomesDepartamentoAoAlterarIDDepartamento()
carregarMotivoAoAlterarCategoria()
carregarCategoria()
adicionarCamposAceitarSomenteInteiro()

