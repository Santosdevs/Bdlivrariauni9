const API_URL = 'http://localhost:5000/api/livro'; // Adjust this based on your API URL

document.addEventListener("DOMContentLoaded", () => {
    loadLivros();
    document.getElementById("form").addEventListener("submit", handleFormSubmit);
});

// Fetch all books from the API
async function loadLivros() {
    const response = await fetch(API_URL);
    const livros = await response.json();
    const livrosList = document.getElementById("livros");
    livrosList.innerHTML = "";

    livros.forEach((livro) => {
        const li = document.createElement("li");
        li.innerHTML = `
      <strong>${livro.nomeLivro}</strong> by ${livro.autor} (${livro.editora})
      <button onclick="editLivro(${livro.idLivro})">Editar</button>
      <button onclick="deleteLivro(${livro.idLivro})">Excluir</button>
    `;
        livrosList.appendChild(li);
    });
}

// Handle form submission for adding/editing a book
async function handleFormSubmit(event) {
    event.preventDefault();
    const livro = {
        nomeLivro: document.getElementById("nomeLivro").value,
        autor: document.getElementById("autor").value,
        editora: document.getElementById("editora").value,
        preco: document.getElementById("preco").value,
        quantidadePag: document.getElementById("quantidadePag").value,
        categoria: document.getElementById("categoria").value
    };
    const livroId = document.getElementById("livroId").value;

    if (livroId) {
        // Update existing book
        await fetch(${ API_URL } / ${ livroId }, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(livro)
        });
    } else {
        // Add new book
        await fetch(API_URL, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(livro)
        });
    }

    loadLivros();
    document.getElementById("form").reset();
}

// Edit a book
async function editLivro(id) {
    const response = await fetch(${ API_URL } / ${ id });
    const livro = await response.json();

    document.getElementById("livroId").value = livro.idLivro;
    document.getElementById("nomeLivro").value = livro.nomeLivro;
    document.getElementById("autor").value = livro.autor;
    document.getElementById("editora").value = livro.editora;
    document.getElementById("preco").value = livro.preco;
    document.getElementById("quantidadePag").value = livro.quantidadePag;
    document.getElementById("categoria").value = livro.categoria;
}

// Delete a book
async function deleteLivro(id) {
    await fetch(${ API_URL } / ${ id }, { method: "DELETE" });
    loadLivros();
}