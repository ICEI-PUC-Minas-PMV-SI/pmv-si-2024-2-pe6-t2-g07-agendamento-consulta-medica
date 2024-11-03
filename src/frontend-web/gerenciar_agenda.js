document.getElementById('schedule-form').addEventListener('submit', function (event) {
    event.preventDefault();

    const token = localStorage.getItem('token');
    const doctorId = document.getElementById('doctor-select').value;
    const date = document.getElementById('schedule-date').value;
    const startTime = document.getElementById('start-time').value;
    const endTime = document.getElementById('end-time').value;
    const intervalTime = parseInt(document.getElementById('interval-time').value);

    const scheduleData = {
        doctorId: doctorId,
        date: date,
        startTime: startTime,
        endTime: endTime,
        interval: intervalTime
    };

    fetch('https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Agenda', {
        method: 'POST',
        headers: {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(scheduleData)
    })
        .then(response => {
            if (!response.ok) throw new Error('Erro ao criar a agenda');
            alert('Agenda criada com sucesso!');
            listarAgendas(); // Atualiza a tabela com a nova agenda
        })
        .catch(error => console.error('Erro ao criar a agenda:', error));
});

// Função para listar agendas
function listarAgendas() {
    const token = localStorage.getItem('token');

    fetch('https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Agenda', {
        headers: { 'Authorization': `Bearer ${token}` }
    })
        .then(response => response.json())
        .then(data => {
            const tabela = document.getElementById('appointment-list');
            tabela.innerHTML = '';
            data.forEach(agenda => {
                const tr = document.createElement('tr');
                tr.innerHTML = `
                <td>${agenda.date}</td>
                <td>${agenda.medicoNome}</td>
                <td>${agenda.specialty}</td>
                <td>${agenda.time}</td>
                <td>${agenda.status}</td>
                <td><button class="btn btn-warning">Editar</button> <button class="btn btn-danger">Excluir</button></td>
            `;
                tabela.appendChild(tr);
            });
        })
        .catch(error => console.error('Erro ao listar agendas:', error));
}

listarAgendas();
