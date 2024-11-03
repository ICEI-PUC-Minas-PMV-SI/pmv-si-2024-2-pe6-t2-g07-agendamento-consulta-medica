document.getElementById('gerarRelatorio').addEventListener('click', function () {
    const token = localStorage.getItem('token');
    const dataRange = document.getElementById('dataRange').value;
    const status = document.getElementById('status').value;

    // Verifique se o campo de período está preenchido corretamente
    if (!dataRange) {
        alert('Por favor, selecione um período.');
        return;
    }

    // Parse data range
    const [startDate, endDate] = dataRange.split(' até ');

    // Montar parâmetros para filtro
    const params = new URLSearchParams();
    if (startDate) params.append('startDate', startDate);
    if (endDate) params.append('endDate', endDate);
    if (status) params.append('status', status);

    fetch(`https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Consultas/relatorio?${params.toString()}`, {
        headers: { 'Authorization': `Bearer ${token}` }
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`Erro ${response.status}: ${response.statusText}`);
            }
            return response.json();
        })
        .then(data => {
            const tabelaRelatorio = document.getElementById('tabelaRelatorio').querySelector('tbody');
            tabelaRelatorio.innerHTML = ''; // Limpa a tabela
            data.forEach(consulta => {
                const row = `
                <tr>
                    <td>${consulta.data}</td>
                    <td>${consulta.horario}</td>
                    <td>${consulta.paciente}</td>
                    <td>${consulta.medico}</td>
                    <td>${consulta.especialidade}</td>
                    <td>${consulta.status}</td>
                </tr>
            `;
                tabelaRelatorio.innerHTML += row;
            });
        })
        .catch(error => {
            console.error('Erro ao gerar relatório:', error);
            alert(`Erro ao gerar relatório: ${error.message}. Por favor, tente novamente.`);
        });
});
