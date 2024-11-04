document.addEventListener('DOMContentLoaded', function () {
    const token = localStorage.getItem('token');
    const consultasTable = document.getElementById('consultas-table');
    const errorMessage = document.getElementById('error-message');
    const consultasModal = new bootstrap.Modal(document.getElementById('consultasModal'));

    // Fun��o para carregar as consultas
    function loadConsultas() {
        fetch('https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Consultas', {
            headers: { 'Authorization': `Bearer ${token}` }
        })
            .then(response => response.json())
            .then(data => {
                consultasTable.innerHTML = '';
                data.forEach(consulta => {
                    const row = document.createElement('tr');
                    row.innerHTML = `
                    <td>${consulta.id}</td>
                    <td>${consulta.data}</td>
                    <td>${consulta.horario}</td>
                    <td>${consulta.paciente}</td>
                    <td>${consulta.medico}</td>
                    <td>${consulta.especialidade}</td>
                    <td>
                        <button class="btn btn-primary" onclick="editConsulta(${consulta.id})">Editar</button>
                        <button class="btn btn-danger" onclick="deleteConsulta(${consulta.id})">Excluir</button>
                    </td>
                `;
                    consultasTable.appendChild(row);
                });
            })
            .catch(error => {
                console.error('Erro ao carregar consultas:', error);
                errorMessage.textContent = 'Erro ao carregar consultas. Por favor, tente novamente.';
                errorMessage.style.display = 'block';
            });
    }

    // Fun��o para adicionar ou atualizar consulta
    document.getElementById('consultasForm').addEventListener('submit', function (event) {
        event.preventDefault();
        const id = document.getElementById('consultaId').value;
        const data = document.getElementById('consultaData').value;
        const horario = document.getElementById('consultaHorario').value;
        const paciente = document.getElementById('consultaPaciente').value;
        const medico = document.getElementById('consultaMedico').value;
        const especialidade = document.getElementById('consultaEspecialidade').value;

        const consultaData = { data, horario, paciente, medico, especialidade };

        const url = id
            ? `https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Consultas/${id}`
            : 'https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Consultas';
        const method = id ? 'PUT' : 'POST';

        fetch(url, {
            method,
            headers: { 'Content-Type': 'application/json', 'Authorization': `Bearer ${token}` },
            body: JSON.stringify(consultaData)
        })
            .then(response => {
                if (!response.ok) throw new Error('Erro ao salvar consulta');
                consultasModal.hide();
                loadConsultas();
            })
            .catch(error => {
                console.error(error);
                alert('Erro ao salvar consulta. Por favor, tente novamente.');
            });
    });

    // Fun��o para editar consulta
    window.editConsulta = function (id) {
        fetch(`https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Consultas/${id}`, {
            headers: { 'Authorization': `Bearer ${token}` }
        })
            .then(response => response.json())
            .then(data => {
                document.getElementById('consultaId').value = data.id;
                document.getElementById('consultaData').value = data.data;
                document.getElementById('consultaHorario').value = data.horario;
                document.getElementById('consultaPaciente').value = data.paciente;
                document.getElementById('consultaMedico').value = data.medico;
                document.getElementById('consultaEspecialidade').value = data.especialidade;
                consultasModal.show();
            })
            .catch(error => {
                console.error('Erro ao carregar dados da consulta:', error);
                alert('Erro ao carregar dados da consulta. Por favor, tente novamente.');
            });
    };

    // Fun��o para excluir consulta
    window.deleteConsulta = function (id) {
        if (confirm('Tem certeza que deseja excluir esta consulta?')) {
            fetch(`https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Consultas/${id}`, {
                method: 'DELETE',
                headers: { 'Authorization': `Bearer ${token}` }
            })
                .then(response => {
                    if (!response.ok) throw new Error('Erro ao excluir consulta');
                    loadConsultas();
                })

