const apiUrl = "https://localhost:7264/api/User";

// Função para carregar os usuários da API
export function loadUsers() {
  const userTable = document
    .getElementById("userTable")
    .getElementsByTagName("tbody")[0];

  fetch(`${apiUrl}/all`)
    .then((response) => response.json())
    .then((users) => {
      userTable.innerHTML = "";
      users.forEach((user) => {
        const row = userTable.insertRow();
        row.setAttribute("data-id", user.idUser);
        row.innerHTML = `
                    <td>${user.idUser}</td>
                    <td><span class="editable">${user.name.first}</span></td>
                    <td><span class="editable">${user.name.last}</span></td>
                    <td><span class="editable">${user.email}</span></td>
                    <td>
                        <button class="edit-btn">Editar</button>
                    </td>
                `;
      });
      addEventListeners();
    })
    .catch((error) => console.error("Erro ao carregar usuários:", error));
}

export async function loadSpecificUser(id) {
  try {
    const response = await fetch(`${apiUrl}/${id}`);
    if (!response.ok) {
      throw new Error("Network response was not ok");
    }
    const userData = await response.json();
    return userData; // Retorna os dados do usuário
  } catch (error) {
    console.error("Erro ao carregar o usuário:", error);
    return null; // Retorna null em caso de erro
  }
}

export async function updateUser(updatedUser) {
  try {
    const response = await fetch(`${apiUrl}/update/${updatedUser.idUser}`, {
      method: "PUT", // Método HTTP para atualizar
      headers: {
        "Content-Type": "application/json", // Define o tipo de conteúdo
      },
      body: JSON.stringify(updatedUser), // Converte o objeto em JSON
    });

    if (!response.ok) {
      throw new Error(`Erro ao atualizar usuário: ${response.statusText}`);
    }

    const result = await response.json(); // Retorna o resultado da API, se necessário
    return result; // Retorna o resultado da atualização
  } catch (error) {
    console.error("Erro na função updateUser:", error);
    throw error; // Rejoga o erro para que possa ser tratado na chamada
  }
}

// Função para adicionar eventos aos botões
function addEventListeners() {
  const editButtons = document.querySelectorAll(".edit-btn");

  editButtons.forEach((button) => button.addEventListener("click", editUser));
}

function editUser(event) {
  location.href = `/pages/editUser.html?id=${event.target.parentElement.parentElement.getAttribute(
    "data-id"
  )}`;
}
