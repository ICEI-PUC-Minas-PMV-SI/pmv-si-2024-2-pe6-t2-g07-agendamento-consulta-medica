// js/login.js

document.getElementById('login-form').addEventListener('submit', function (event) {
    event.preventDefault();

    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;

    fetch('https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Usuarios/authenticate', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email: email, senha: password })
    })
        .then(response => response.json())
        .then(data => {
            if (data.token) {
                // Armazena o token e redireciona para a página inicial
                localStorage.setItem('token', data.token);
                window.location.href = 'pagina_inicial.html'; // Ajuste o caminho conforme necessário
            } else {
                // Exibe mensagem de erro se o login falhar
                document.getElementById('error-message').style.display = 'block';
            }
        })
        .catch(error => {
            console.error('Erro ao fazer login:', error);
            document.getElementById('error-message').style.display = 'block';
        });
});
