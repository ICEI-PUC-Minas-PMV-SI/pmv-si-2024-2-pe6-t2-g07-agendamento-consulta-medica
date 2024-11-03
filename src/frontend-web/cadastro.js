// Função para validar o formulário e cadastrar usuário
document.addEventListener("DOMContentLoaded", function () {
    const form = document.querySelector("form");

    form.addEventListener("submit", function (event) {
        event.preventDefault();  // Previne o envio padrão do formulário

        // Pegar valores dos campos
        const nome = document.getElementById("name").value.trim();
        const email = document.getElementById("email").value.trim();
        const tipoUsuario = document.getElementById("role").value;
        const senha = document.getElementById("password").value;
        const confirmarSenha = document.getElementById("confirm-password").value;

        // Validações
        if (!nome) {
            alert("Por favor, preencha o nome completo.");
            return;
        }

        if (!email || !validarEmail(email)) {
            alert("Por favor, insira um e-mail válido.");
            return;
        }

        if (!tipoUsuario) {
            alert("Por favor, selecione o tipo de usuário.");
            return;
        }

        if (!validarSenha(senha)) {
            alert("A senha deve ter pelo menos 8 caracteres, incluindo uma letra maiúscula, uma letra minúscula, um número e um caractere especial.");
            return;
        }

        if (senha !== confirmarSenha) {
            alert("As senhas não coincidem.");
            return;
        }

        // Simulação do cadastro
        const novoUsuario = {
            nome: nome,
            email: email,
            tipoUsuario: tipoUsuario,
            senha: senha
        };

        // Aqui você pode enviar os dados para um back-end, exemplo:
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
        //     alert("Usuário cadastrado com sucesso!");
        // })
        // .catch(error => console.error('Erro:', error));

        console.log("Usuário cadastrado com sucesso:", novoUsuario);
        alert("Usuário cadastrado com sucesso!");

        // Limpar o formulário
        form.reset();
    });

    // Função para validar e-mail
    function validarEmail(email) {
        const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return re.test(String(email).toLowerCase());
    }

    // Função para validar a senha com requisitos de segurança
    function validarSenha(senha) {
        const minLength = 8;
        const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
        if (senha.length < minLength) {
            return false;
        }
        return regex.test(senha);
    }
});
