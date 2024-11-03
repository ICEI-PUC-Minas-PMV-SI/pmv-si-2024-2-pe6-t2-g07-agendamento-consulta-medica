document.addEventListener('DOMContentLoaded', function () {
    const token = localStorage.getItem('token');
    const historicoConsultas = document.getElementById('historico-consultas');
    const filtroData = document.getElementById('filtroData');

    // Função para carregar consultas futuras
    function carregarConsultasFuturas() {
        fetch('https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Consultas/futuras', {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then(response => response.json())
            .then(data => {
                const tabelaFuturas = document.getElementById('consulta-futura');
                tabelaFuturas.innerHTML = '';
                data.forEach(consulta => {
                    const row = document.createElement('tr');
                    row.innerHTML = `
                    <td>${consulta.data}</td>
                    <td>${consulta.horario}</td>
                    <td>${consulta.medico}</td>
                    <td>${consulta.especialidade}</td>
                    <td><span class="badge bg-success">${consulta.status}</span></td>
                    <td><button class="btn btn-danger btn-sm" onclick="cancelarConsulta(${consulta.id})">Cancelar</button></td>
                `;
                    tabelaFuturas.appendChild(row);
                });
            });
    }

    // Função para cancelar consulta
    window.cancelarConsulta = function (id) {
        if (confirm('Tem certeza que deseja cancelar esta consulta?')) {
            fetch(`https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Consultas/${id}`, {
                method: 'PATCH',
                headers: {
                    'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ status: 'Cancelada' })
            })
                .then(response => {
                    if (response.ok) {
                        alert('Consulta cancelada com sucesso!');
                        carregarConsultasFuturas();
                        carregarHistoricoConsultas();
                    } else {
                        throw new Error('Falha ao cancelar consulta');
                    }
                })
                .catch(error => console.error('Erro ao cancelar consulta:', error));
        }
    };

    // Função para carregar o histórico de consultas
    function carregarHistoricoConsultas() {
        fetch('https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Consultas/historico', {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        })
            .then(response => response.json())
            .then(data => {
                historicoConsultas.innerHTML = '';
                data.forEach(consulta => {
                    const row = document.createElement('tr');
                    row.innerHTML = `
                    <td>${consulta.data}</td>
                    <td>${consulta.horario}</td>
                    <td>${consulta.medico}</td>
                    <td>${consulta.especialidade}</td>
                    <td><span class="badge ${consulta.status === 'Realizada' ? 'bg-success' : 'bg-secondary'}">${consulta.status}</span></td>
                `;
                    historicoConsultas.appendChild(row);
                });
            });
    }

    // Carregar dados iniciais
    carregarConsultasFuturas();
    carregarHistoricoConsultas();

    // Filtragem de histórico por data
    filtroData.addEventListener('input', function () {
        const dataFiltro = new Date(filtroData.value);
        const linhasHistorico = historicoConsultas.querySelectorAll('tr');

        linhasHistorico.forEach(linha => {
            const dataConsulta = new Date(linha.cells[0].innerText.split('/').reverse().join('-'));

            if (isNaN(dataFiltro.getTime()) || dataConsulta.getTime() === dataFiltro.getTime()) {
                linha.style.display = '';
            } else {
                linha.style.display = 'none';
            }
        });
    });
});
