document.getElementById('new-appointment-form').addEventListener('submit', async (event) => {
    event.preventDefault();

    const date = document.getElementById('date').value;
    const time = document.getElementById('time').value;
    const doctor = document.getElementById('doctor').value;
    const location = document.getElementById('location').value;

    const response = await fetch('/appointments', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ date, time, doctor, location })
    });

    if (response.ok) {
        alert('Consulta cadastrada com sucesso!');
        window.location.href = 'consultas.html';
    } else {
        alert('Erro ao cadastrar consulta.');
    }
});
