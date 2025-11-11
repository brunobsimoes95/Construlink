
let dotNetReference;
var video = "";
var labeledFaceDescriptors = "";

function setDotNetReference(ref) {
    if (ref) {
        dotNetReference = ref;
        console.log("DotNet reference set successfully.");
    } else {
        console.error("Failed to set DotNet reference.");
    }
}

//função para verificar o login facial
function run_faciallogin() {

    video = document.getElementById("cam");
    const faceMatcher = new faceapi.FaceMatcher(labeledFaceDescriptors, 0.5); //ajusta o limite de confiança

    startWebcam();
    function startWebcam() {
        navigator.mediaDevices
            .getUserMedia({
                video: true,
                audio: false,
            })
            .then((stream) => {
                video.srcObject = stream;
                video.addEventListener('loadedmetadata', () => {
                    const aspectRatio = video.videoWidth / video.videoHeight;
                    let newWidth = video.clientWidth;
                    let newHeight = newWidth / aspectRatio;

                    if (newHeight > video.clientHeight) {
                        newHeight = video.clientHeight;
                        newWidth = newHeight * aspectRatio;
                    }

                    video.width = newWidth;
                    video.height = newHeight;
                });
            })
            .catch((error) => {
                console.error(error);
            });
    }


    video.addEventListener("play", () => {
        // carrega o ficheiro JSON com os descriptors
        //const labeledFaceDescriptors = await loadLabeledFaceDescriptors();

        if (document.getElementById("loading")) {
            document.getElementById("loading").setAttribute('style', 'display:none');;
        }

        const canvas = faceapi.createCanvasFromMedia(video);
        canvas.setAttribute('style', 'left:0');
        canvas.setAttribute('class', 'facialcanva');
        document.getElementById("login_face").append(canvas);

        const displaySize = { width: video.width, height: video.height };
        faceapi.matchDimensions(canvas, displaySize);

        let consecutiveKnownDetections = 0;
        let shouldStopProcessing = false;


        // Before setting up the new interval, clear the previous one if exists
        if (processingIntervalId) {
            clearInterval(processingIntervalId);
        }

        processingIntervalId = setInterval(async () => {
            /*
             const detections = await faceapi
               .detectAllFaces(video, new faceapi.TinyFaceDetectorOptions())
               .withFaceLandmarks()
               .withFaceExpressions()
               .withAgeAndGender()       
               .withFaceDescriptors(); 
             */
            const detections = await faceapi
                .detectAllFaces(video, new faceapi.TinyFaceDetectorOptions())
                .withFaceLandmarks()
                .withFaceDescriptors();
            //const detections = await faceapi
            //    .detectAllFaces(video, new faceapi.SsdMobilenetv1Options())
            //    .withFaceLandmarks()
            //    .withFaceDescriptors();

            const resizedDetections = faceapi.resizeResults(detections, displaySize);
            canvas.getContext("2d").clearRect(0, 0, canvas.width, canvas.height);

            const threshold = 0.5; // Limite inicial
            const dynamicThreshold = threshold + 0.2; // Ajuste dinâmico

            const results = resizedDetections.map((d) => {
                //const isAboveThreshold = d.detection._score > dynamicThreshold;
                const isAboveThreshold = true;
                if (isAboveThreshold) {
                    // verifica se é uma pessoa real ou uma foto pela textura
                    //var textureAnalysisThreshold = 35 * d.detection.box.height / 150;
                    //const faceAreaTexture = getFaceAreaTexture(d.landmarks);
                    //const resultValue = faceAreaTexture - textureAnalysisThreshold;
                    //const isRealPerson = resultValue > -1 && resultValue < 1; //ajustar conforme necessário      
                    const isRealPerson = true;
                    if (isRealPerson) {
                        return faceMatcher.findBestMatch(d.descriptor);
                    } else {
                        return { label: "Foto" };
                    }
                } else {
                    return { label: "Foto" };
                }
            });

            results.forEach((result, i) => {
                const box = resizedDetections[i].detection.box;
                var drawBox = "";

                if (result.label !== "unknown" && result.label !== "Foto") {
                    consecutiveKnownDetections++;
                    drawBox = new faceapi.draw.DrawBox(box, {
                        label: result.label.split("|")[0],
                        boxColor: '#7fbc55',
                    });
                } else {
                    consecutiveKnownDetections = 0;
                    drawBox = new faceapi.draw.DrawBox(box, {
                        label: '',
                        boxColor: '#000000',
                    });
                }

                drawBox.draw(canvas);

                //toda a informação que pode ser colocada
                //faceapi.draw.drawDetections(canvas, resizedDetections)
                //faceapi.draw.drawFaceLandmarks(canvas, resizedDetections)
                //faceapi.draw.drawFaceExpressions(canvas, resizedDetections)
                /*
                resizedDetections.forEach( detection => {
                  const box = detection.detection.box
                  const drawBox = new faceapi.draw.DrawBox(box, { label: Math.round(detection.age) + " anos " + detection.gender })
                  drawBox.draw(canvas)
                })      
                */

                //LOGIN
                if (consecutiveKnownDetections >= 5) {
                    shouldStopProcessing = true;
                    consecutiveKnownDetections = 0;

                    // Invoke the Blazor method
                    let stringValue = result.label.split("|")[1];
                    let intValue = parseInt(stringValue, 10);
                    if (isNaN(intValue)) {
                        intValue = 0;
                    }

                    if (dotNetReference) {
                        dotNetReference.invokeMethodAsync("AxClock.Pages.Controle.LoginUnificado.LogUser", intValue)
                            .catch(error => console.error("Interop error:", error));
                    } else {
                        console.error("dotNetReference is null or undefined.");
                    }
                }
            });

        }, 50);
    });


    // Funções para detetar se é uma pessoa real ou uma foto baseado na textura
    function getFaceAreaTexture(faceLandmarks) {
        const positions = faceLandmarks.positions;

        const minX = Math.min(...positions.map(point => point.x));
        const maxX = Math.max(...positions.map(point => point.x));
        const minY = Math.min(...positions.map(point => point.y));
        const maxY = Math.max(...positions.map(point => point.y));

        const width = maxX - minX;
        const height = maxY - minY;

        const normalizedWidth = width / faceLandmarks._imgDims._width;
        const normalizedHeight = height / faceLandmarks._imgDims._height;

        const stdDevX = standardDeviation(positions.map(point => point.x));
        const stdDevY = standardDeviation(positions.map(point => point.y));

        var texture = (stdDevX + stdDevY) / 2;
        texture /= (normalizedWidth + normalizedHeight) / 2;

        return texture;
    }
    function standardDeviation(values) {
        const avg = average(values);
        const squareDiffs = values.map((value) => Math.pow(value - avg, 2));
        const avgSquareDiff = average(squareDiffs);
        const stdDev = Math.sqrt(avgSquareDiff);
        return stdDev;
    }
    function average(values) {
        const sum = values.reduce((acc, value) => acc + value, 0);
        return sum / values.length;
    }

};


//parar a função
function stop_faciallogin() {
    if (streamReference) {
        // para a câmara
        streamReference.getTracks().forEach(track => track.stop());
    }

    if (processingIntervalId) {
        // limpa o intervalo
        clearInterval(processingIntervalId);
    }

    if (video != "" && video.srcObject) {
        video.srcObject.getTracks().forEach(track => track.stop());
        video.srcObject = null;
    }

    const canvas = document.querySelector('.facialcanva');
    if (canvas) {
        canvas.remove();
    }
}


//carregar descriptors
function load_descriptors(dbfacedescriptors) {

    var jsonStrings = dbfacedescriptors.split("###");
    var mergedData = [];
    jsonStrings.forEach(function (jsonString) {
        try {
            if (jsonString != "") {
                var jsonObject = JSON.parse(jsonString);
                mergedData = mergedData.concat(jsonObject);
            }
        } catch (error) {
            console.error("Error parsing JSON:", error);
        }
    });

    if (!Array.isArray(mergedData)) {
        throw new Error("Invalid format: descriptors must be an array.");
    }

    const labeledDescriptors = mergedData;
    //const labeledDescriptors = await response.json();
    if (!Array.isArray(labeledDescriptors)) {
        throw new Error("Invalid format: descriptors must be an array.");
    }

    // Convert o JSON para o formato esperado
    const faceDescriptors = labeledDescriptors.map(({ label, descriptions }) => {
        if (!label || !Array.isArray(descriptions)) {
            throw new Error("Invalid format: each descriptor must have a label and an array of descriptions.");
        }

        return new faceapi.LabeledFaceDescriptors(
            label,
            descriptions.map((descriptorObject) => {
                if (!descriptorObject || typeof descriptorObject !== "object") {
                    throw new Error("Invalid format: each description must be an object.");
                }

                return new Float32Array(Object.values(descriptorObject));
            })
        );
    });

    labeledFaceDescriptors = faceDescriptors;

    Promise.all([
        faceapi.nets.tinyFaceDetector.loadFromUri("/js/face/models"),
        faceapi.nets.faceRecognitionNet.loadFromUri("js/face/models"),
        faceapi.nets.faceLandmark68Net.loadFromUri("js/face/models"),
    ]);
}
