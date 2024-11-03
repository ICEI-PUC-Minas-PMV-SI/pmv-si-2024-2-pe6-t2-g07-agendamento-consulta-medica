// Fun��o para validar o formul�rio e cadastrar usu�rio
document.addEventListener("DOMContentLoaded", function () {
    const form = document.querySelector("form");

    form.addEventListener("submit", function (event) {
        event.preventDefault();  // Previne o envio padr�o do formul�rio

        // Pegar valores dos campos
        const nome = document.getElementById("name").value.trim();
        const email = document.getElementById("email").value.trim();
        const tipoUsuario = document.getElementById("role").value;
        const senha = document.getElementById("password").value;
        const confirmarSenha = document.getElementById("confirm-password").value;

        // Valida��es
        if (!nome) {
            alert("Por favor, preencha o nome completo.");
            return;
        }

        if (!email || !validarEmail(email)) {
            alert("Por favor, insira um e-mail v�lido.");
            return;
        }

        if (!tipoUsuario) {
            alert("Por favor, selecione o tipo de usu�rio.");
            return;
        }

        if (!validarSenha(senha)) {
            alert("A senha deve ter pelo menos 8 caracteres, incluindo uma letra mai�scula, uma letra min�scula, um n�mero e um caractere especial.");
            return;
        }

        if (senha !== confirmarSenha) {
            alert("As senhas n�o coincidem.");
            return;
        }

        // Simula��o do cadastro
        const novoUsuario = {
            nome: nome,
            email: email,
            tipoUsuario: tipoUsuario,
            senha: senha
        };

        // Aqui voc� pode enviar os dados para um back-end, exemplo:
        // fetch('/api/cadastro', {
        //     method: 'POST',
        //     body: JSON.stringify(novoUsuario),
        //     headers: {
        //         'Content-Type': 'application/json'
        //     }
        // })
        // .then(response => response.json())
        // .then(data => {
        //     console.log(data);
        //     alert("Usu�rio cadastrado com sucesso!");
        // })
        // .catch(error => console.error('Erro:', error));

        console.log("Usu�rio cadastrado com sucesso:", novoUsuario);
        alert("Usu�rio cadastrado com sucesso!");

        // Limpar o formul�rio
        form.reset();
    });

    // Fun��o para validar e-mail
    function validarEmail(email) {
        const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return re.test(String(email).toLowerCase());
    }

    // Fun��o para validar a senha com requisitos de seguran�a
    function validarSenha(senha) {
        const minLength = 8;
        const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
        if (senha.length < minLength) {
            return false;
        }
        return regex.test(senha);
    }
});
