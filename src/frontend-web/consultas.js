            document.addEventListener('DOMContentLoaded', function() {
            const token = localStorage.getItem('token');
            const usuariosTable = document.getElementById('usuarios-table');
            const consultasTable = document.getElementById('consultas-table');
            const errorMessage = document.getElementById('error-message');
            const idHeader = document.getElementById('id-u-header','id-c-header'); // Adiciona um ID ao cabeçalho ID
            let sortAsc = true; // Variável para alternar entre ordenação ascendente e descendente

            idHeader.addEventListener('click', function() {
                sortAsc = !sortAsc;
                loadUsuarios(sortAsc);
            });

            // Função para carregar os usuários
            
            function loadUsuarios(sortAsc) { 
                Promise.all([ 
                fetch('https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Usuarios', {
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }    
                }).then(response => response.json()),
                fetch('https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Consultas', {
                    headers: {
                        'Authorization': `Bearer ${token}`
                    }
                }).then(response => response.json())    
                ])
                .then(async ([Udata,Cdata]) => {
                    if (Udata.items && Array.isArray(Udata.items) && Cdata.items && Array.isArray(Cdata.items)) {
                        usuariosTable.innerHTML = ''; // Limpa a tabela
                        Udata.items.sort((a, b) => sortAsc ? a.id - b.id : b.id - a.id); // Ordena os itens por ID
                        Udata.items.forEach(usuario => {
                            const formattedDate = new Date(usuario.dataNascimento).toLocaleDateString('pt-BR'); // Formata a data
                            const row = document.createElement('tr');
                            row.innerHTML = `
                                <td>${usuario.id}</td>
                                <td contenteditable="true" class="editable">${usuario.nome}</td>
                                <td contenteditable="true" class="editable">${usuario.cpf}</td>
                                <td contenteditable="true" class="editable">${usuario.email}</td>
                                <td contenteditable="true" class="editable">${usuario.telefone}</td>
                                <td contenteditable="true" class="editable">${formattedDate}</td>
                                <td class="editable">
                                    <select>
                                        <option value="Feminino" ${usuario.sexo === 1 ? 'selected' : ''}>Feminino</option>
                                        <option value="Masculino" ${usuario.sexo === 2 ? 'selected' : ''}>Masculino</option>
                                    </select>
                                </td>
                                <td class="editable">
                                    <select>
                                        <option value="0" ${usuario.perfil === 0 ? 'selected' : ''}>Administrador</option>
                                        <option value="1" ${usuario.perfil === 1 ? 'selected' : ''}>Médico</option>
                                        <option value="2" ${usuario.perfil === 2 ? 'selected' : ''}>Paciente</option>
                                    </select>
                                </td>
                                <td contenteditable="true" class="editable">${usuario.senha.slice(0, 8).replace(/./g, '*')}</td>
                                <td class="action-buttons">
                                    <button class="btn btn-primary" onclick="updateUsuario(this)">Atualizar</button>
                                    <button class="btn btn-danger" onclick="deleteUsuario(${usuario.id})">Excluir</button>
                                </td>
                            `;
                            usuariosTable.appendChild(row);
                        });

                        Cdata.items.forEach(consulta => {
                            const dataConsulta = new Date(consulta.dataConsulta).toLocaleDateString('pt-BR'); // Formata a data
                            const row = document.createElement('tr');
                            row.innerHTML = `
                                <td>${consulta.id}</td>
                                <td contenteditable="true" class="editable">${dataConsulta}</td>
                                <td contenteditable="true" class="editable">${consulta.horaConsulta}</td>
                         
                                
                                <td class="action-buttons">
                                    <button class="btn btn-primary" onclick="updateConsulta(this)">Atualizar</button>
                                    <button class="btn btn-danger" onclick="deleteConsulta(${consulta.id})">Excluir</button>
                                </td>
                            `;
                            consultasTable.appendChild(row);
                        });
                    } else {
                        errorMessage.textContent = 'Formato de dados inválido recebido da API.';
                        errorMessage.style.display = 'block';
                    }
                }) 
                .catch(error => {
                    console.error('Erro ao carregar usuários:', error);
                    errorMessage.textContent = 'Erro ao carregar usuários. Por favor, tente novamente.';
                    errorMessage.style.display = 'block';
                });
            }

            // Função para atualizar o usuário
            window.updateUsuario = function(button) {
                    const row = button.closest('tr');
                    const id = row.cells[0].textContent;

                    const dateParts = row.cells[5].textContent.split('/');
                    const dateObject = new Date(`${dateParts[2]}-${dateParts[1]}-${dateParts[0]}T00:00:00`);
                    const dataNascimentoISO = dateObject.toISOString();


                    const updatedUser = {
                        id: id,
                        nome: row.cells[1].textContent,
                        cpf: row.cells[2].textContent,
                        email: row.cells[3].textContent,
                        senha: row.cells[8].textContent.replace(/\*/g, ''),  // Converte a senha anonimizada de volta
                        telefone: row.cells[4].textContent,
                        dataNascimento: dataNascimentoISO,  // Ajusta a data para ISO string
                        sexo: row.cells[6].querySelector('select').value === 'Feminino' ? 1 : 2,
                        perfil: parseInt(row.cells[7].querySelector('select').value, 10)
                    };

                    fetch(`https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Usuarios/${id}`, {
                        method: 'PUT',
                        headers: {
                            'Content-Type': 'application/json',
                            'Authorization': `Bearer ${token}`
                        },
                        body: JSON.stringify(updatedUser)
                    })
                    .then(response => {
                        if (!response.ok) {
                            return response.text().then(text => { throw new Error(text) });
                        }
                        alert('Usuário atualizado com sucesso!');
                        location.reload();  // Recarrega a página após a atualização
                    })
                    .catch(error => {
                        console.error('Erro ao atualizar usuário:', error);
                        errorMessage.textContent = 'Erro ao atualizar usuário. Por favor, tente novamente.';
                        errorMessage.style.display = 'block';
                    });
                };

            // Função para excluir o usuário
            window.deleteUsuario = function(id) {
                if (confirm('Tem certeza que deseja excluir este usuário?')) {
                    fetch(`https://consultafacil-eyfffgehf5bvesbx.brazilsouth-01.azurewebsites.net/api/Usuarios/${id}`, {
                        method: 'DELETE',
                        headers: {
                            'Authorization': `Bearer ${token}`
                        }
                    })
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Erro ao excluir usuário');
                        }
                        loadUsuarios(); // Recarrega a tabela após a exclusão
                    })
                    .catch(error => {
                        console.error('Erro ao excluir usuário:', error);
                        errorMessage.textContent = 'Erro ao excluir usuário. Por favor, tente novamente.';
                        errorMessage.style.display = 'block';
                    });
                }
            }

            // Carrega os usuários ao carregar a página
            loadUsuarios(true);
        });