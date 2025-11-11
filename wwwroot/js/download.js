// wwwroot/js/utils.js  (por ex.)
 function openFileInNewTab(base64Data, fileName, mimeType) {
    // converte Base64 → Blob
    const byteChars = atob(base64Data);
    const byteNumbers = new Array(byteChars.length);
    for (let i = 0; i < byteChars.length; i++) {
        byteNumbers[i] = byteChars.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: mimeType });

    // cria URL temporário
    const url = URL.createObjectURL(blob);

    // dispara download com o nome pedido
    const a = document.createElement('a');
    a.href = url;
    a.download = fileName;      // <- é aqui que o nome fica fixo
    a.style.display = 'none';
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);

    // limpa
    URL.revokeObjectURL(url);
}

window.openFileInNewTab = openFileInNewTab;
