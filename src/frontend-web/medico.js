// Inicializa o Daterangepicker para seleção de intervalo de datas
$(function () {
    $('#filtroCalendario').daterangepicker({
        locale: {
            format: 'YYYY-MM-DD',
            applyLabel: 'Aplicar',
            cancelLabel: 'Cancelar',
            fromLabel: 'De',
            toLabel: 'Até',
            customRangeLabel: 'Personalizado',
            weekLabel: 'S',
            daysOfWeek: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb'],
            monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
            firstDay: 0
        }
    });
});

// Função para buscar e filtrar a agenda
function filtrarAgenda() {
    const token = localStorage.getItem('token');
    const filtroCalendario = document.getElementById('filtroCalendario').value;
    const [dataInicio, dataFim] = filtroCalendario.split(" até ");

    fetch(`https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Consultas?dataInicio=${dataInicio}&dataFim=${dataFim}`, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    })
        .then(response => response.json())
        .then(data => {
            const agendaTable = document.getElementById('agenda');
            agendaTable.innerHTML = ''; // Limpa a tabela

            data.forEach(consulta => {
                const row = document.createElement('tr');
                row.innerHTML = `
                <td>${consulta.data}</td>
                <td>${consulta.horario}</td>
                <td>${consulta.paciente}</td>
                <td><span class="badge ${consulta.status === 'Confirmado' ? 'bg-success' : consulta.status === 'Cancelado' ? 'bg-danger' : 'bg-warning'}">${consulta.status}</span></td>
                <td>
                    <button class="btn btn-success" onclick="atualizarStatusConsulta(${consulta.id}, 'Confirmado')">Confirmar</button>
                    <button class="btn btn-primary" onclick="atualizarStatusConsulta(${consulta.id}, 'Atendido')">Atendido</button>
                    <button class="btn btn-danger" onclick="atualizarStatusConsulta(${consulta.id}, 'Cancelado')">Cancelar</button>
                </td>
            `;
                agendaTable.appendChild(row);
            });
        })
        .catch(error => console.error('Erro ao filtrar a agenda:', error));
}

// Função para atualizar o status de uma consulta
function atualizarStatusConsulta(id, status) {
    const token = localStorage.getItem('token');

    fetch(`https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Consultas/${id}`, {
        method: 'PATCH',
        headers: {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ status })
    })
        .then(response => {
            if (response.ok) {
                alert(`Status da consulta atualizado para: ${status}`);
                filtrarAgenda(); // Atualiza a agenda após a alteração
            } else {
                throw new Error('Falha ao atualizar o status da consulta');
            }
        })
        .catch(error => console.error('Erro ao atualizar o status:', error));
}
