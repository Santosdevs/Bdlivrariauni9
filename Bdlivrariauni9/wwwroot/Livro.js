const API_URL = 'http://localhost:5158/api/livro';

document.addEventListener("DOMContentLoaded", () => {
    loadLivros();
    document.getElementById("form").addEventListener("submit", handleFormSubmit);
});

// Exibe uma mensagem de erro no UI
function showError(message) {
    const errorMessageElement = document.getElementById("error-message");
    if (errorMessageElement) {
        errorMessageElement.textContent = message;
        errorMessageElement.style.display = 'block';
    } else {
        alert(message); // Fallback para alert caso não tenha o elemento
    }
}

// Fetch all books from the API
async function loadLivros() {
    try {
        const response = await fetch(API_URL);

        if (!response.ok) {
            const errorText = await response.text();
            console.error(`Erro ao buscar livros: ${errorText}`);
            showError(`Erro ao carregar livros: ${errorText}`);
            return;
        }

        const livros = await response.json();

        // Verifique se 'livros' é realmente um array
        if (!Array.isArray(livros)) {
            throw new Error("Resposta da API não é um array válido.");
        }

        const livrosList = document.getElementById("livros");
        livrosList.innerHTML = "";

        livros.forEach((livro) => {
            const li = document.createElement("li");
            li.innerHTML = `
                <strong>${livro.nomeLivro}</strong> por ${livro.autor} (${livro.editora})
                <button onclick="editLivro(${livro.idLivro})">Editar</button>
                <button onclick="deleteLivro(${livro.idLivro})">Excluir</button>
            `;
            livrosList.appendChild(li);
        });
    } catch (error) {
        console.error("Erro ao carregar livros:", error);
        showError("Erro ao carregar livros. Verifique o console para mais detalhes.");
    }
}

}

// Handle form submission for adding/editing a book
async function handleFormSubmit(event) {
    event.preventDefault();
    const livro = {
        nomeLivro: document.getElementById("nomeLivro").value,
        autor: document.getElementById("autor").value,
        editora: document.getElementById("editora").value,
        preco: parseFloat(document.getElementById("preco").value),
        quantidadePag: parseInt(document.getElementById("quantidadePag").value),
        categoria: document.getElementById("categoria").value
    };
    const livroId = document.getElementById("livroId").value;

    try {
        let response;
        if (livroId) {
            response = await fetch(`${API_URL}/${livroId}`, {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(livro)
            });
        } else {
            response = await fetch(API_URL, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(livro)
            });
        }

        if (!response.ok) {
            const errorText = await response.text();
            console.error(`Erro ao salvar livro: ${errorText}`);
            showError(`Erro ao salvar livro: ${errorText}`);
            return;
        }

        loadLivros();
        document.getElementById("form").reset();
    } catch (error) {
        console.error("Erro ao enviar formulário:", error);
        showError("Erro ao enviar formulário. Verifique o console para mais detalhes.");
    }
}

// Edit a book
async function editLivro(id) {
    try {
        const response = await fetch(`${API_URL}/${id}`);

        if (!response.ok) {
            const errorText = await response.text();
            console.error(`Erro ao buscar livro: ${errorText}`);
            showError(`Erro ao buscar livro para edição: ${errorText}`);
            return;
        }

        const livro = await response.json();
        document.getElementById("livroId").value = livro.idLivro;
        document.getElementById("nomeLivro").value = livro.nomeLivro;
        document.getElementById("autor").value = livro.autor;
        document.getElementById("editora").value = livro.editora;
        document.getElementById("preco").value = livro.preco;
        document.getElementById("quantidadePag").value = livro.quantidadePag;
        document.getElementById("categoria").value = livro.categoria;
    } catch (error) {
        console.error("Erro ao editar livro:", error);
        showError("Erro ao editar livro. Verifique o console para mais detalhes.");
    }
}

// Delete a book
async function deleteLivro(id) {
    try {
        const response = await fetch(`${API_URL}/${id}`, { method: "DELETE" });

        if (!response.ok) {
            const errorText = await response.text();
            console.error(`Erro ao excluir livro: ${errorText}`);
            showError(`Erro ao excluir livro: ${errorText}`);
            return;
        }

        loadLivros();
    } catch (error) {
        console.error("Erro ao excluir livro:", error);
        showError("Erro ao excluir livro. Verifique o console para mais detalhes.");
    }
}
