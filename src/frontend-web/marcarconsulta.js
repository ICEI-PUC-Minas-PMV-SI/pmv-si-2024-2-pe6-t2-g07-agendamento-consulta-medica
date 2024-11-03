// Inicializa o Date Range Picker para selecionar o intervalo de datas
$(function () {
    $('#calendario').daterangepicker({
        locale: {
            format: 'YYYY-MM-DD',
            separator: " até ",
            applyLabel: "Aplicar",
            cancelLabel: "Cancelar",
            daysOfWeek: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sáb"],
            monthNames: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"],
            firstDay: 1
        }
    });
});

// Função para buscar consultas disponíveis da API
document.getElementById('buscarConsultas').addEventListener('click', function () {
    const token = localStorage.getItem('token');
    const especialidade = document.getElementById('especialidade').value;
    const medico = document.getElementById('medico').value;
    const periodo = document.getElementById('calendario').value.split(' até ');

    fetch(`https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Consultas`, {
        headers: {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            const tbody = document.getElementById('consultasDisponiveis');
            tbody.innerHTML = '';

            data.forEach(consulta => {
                const tr = document.createElement('tr');
                tr.innerHTML = `
                <td>${consulta.data}</td>
                <td>${consulta.horario}</td>
                <td>${consulta.medico}</td>
                <td>${consulta.especialidade}</td>
                <td><button class="btn btn-primary agendar-btn" data-data="${consulta.data}" data-horario="${consulta.horario}" data-medico="${consulta.medico}">Agendar</button></td>
            `;
                tbody.appendChild(tr);
            });

            document.querySelectorAll('.agendar-btn').forEach(button => {
                button.addEventListener('click', function () {
                    const data = this.getAttribute('data-data');
                    const horario = this.getAttribute('data-horario');
                    const medico = this.getAttribute('data-medico');

                    document.getElementById('dataModal').textContent = data;
                    document.getElementById('horarioModal').textContent = horario;
                    document.getElementById('medicoModal').textContent = medico;

                    const confirmModal = new bootstrap.Modal(document.getElementById('confirmModal'));
                    confirmModal.show();
                });
            });
        })
        .catch(error => console.error('Erro ao buscar consultas:', error));
});

// Função para confirmar o agendamento
document.getElementById('confirmAgendar').addEventListener('click', function () {
    const confirmModal = bootstrap.Modal.getInstance(document.getElementById('confirmModal'));
    alert('Consulta agendada com sucesso!');
    confirmModal.hide();
});
