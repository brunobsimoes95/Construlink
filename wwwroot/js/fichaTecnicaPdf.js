
// Adicionar estilos para o spinner
(function () {
    var style = document.createElement('style');
    style.id = 'pdf-download-styles';
    style.innerHTML = `
        #pdf-loading-spinner {
            margin-top: 10px; 
            width: 50px; 
            height: 50px; 
            border: 5px solid #f3f3f3;
            border-top: 5px solid #3498db; 
            border-radius: 50%; 
            animation: spin 2s linear infinite;
            margin-left: auto; 
            margin-right: auto;
        }
        
        @-webkit-keyframes spin {
            0% { -webkit-transform: rotate(0deg); }
            100% { -webkit-transform: rotate(360deg); }
        }
        
        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }
    `;
    document.head.appendChild(style);
})();

// Função para download do PDF
window.downloadFichaTecnicaPdf = async function (empresaId, artigoId) {
    try {
        // Mostrar um indicador de carregamento
        const loadingElement = document.createElement('div');
        loadingElement.id = 'pdf-loading';
        loadingElement.innerHTML = `
            <div style="position: fixed; top: 0; left: 0; width: 100%; height: 100%; 
                        background-color: rgba(0, 0, 0, 0.5); display: flex; 
                        justify-content: center; align-items: center; z-index: 9999;">
                <div style="background-color: white; padding: 20px; border-radius: 5px; text-align: center;">
                    <span>Gerando PDF...</span>
                    <div id="pdf-loading-spinner"></div>
                </div>
            </div>
        `;
        document.body.appendChild(loadingElement);

        // Fazer a solicitação para o endpoint
        const response = await fetch(`/api/FichaTecnicaPdf/gerar/${empresaId}/${artigoId}`);

        if (!response.ok) {
            throw new Error(`Erro ao gerar o PDF: ${response.status} ${response.statusText}`);
        }

        // Obter o blob do PDF
        const blob = await response.blob();

        // Criar um URL temporário para o blob
        const url = window.URL.createObjectURL(blob);

        // Obter o nome do arquivo da resposta
        const contentDisposition = response.headers.get('content-disposition');
        let fileName = 'FichaTecnica.pdf';

        if (contentDisposition) {
            const fileNameMatch = contentDisposition.match(/filename="?([^"]*)"?/);
            if (fileNameMatch && fileNameMatch[1]) {
                fileName = fileNameMatch[1];
            }
        }

        // Criar um elemento de link para download
        const a = document.createElement('a');
        a.href = url;
        a.download = fileName;
        document.body.appendChild(a);

        // Iniciar o download
        a.click();

        // Limpar recursos
        window.URL.revokeObjectURL(url);
        document.body.removeChild(a);

        // Mostrar mensagem de sucesso
        showToast('PDF gerado com sucesso!', 'bg-success');
    }
    catch (error) {
        console.error('Erro ao baixar PDF:', error);
        showToast('Erro ao gerar o PDF. Verifique o console para mais detalhes.', 'bg-danger');
    }
    finally {
        // Remover o indicador de carregamento
        const loadingElement = document.getElementById('pdf-loading');
        if (loadingElement) {
            document.body.removeChild(loadingElement);
        }
    }
};