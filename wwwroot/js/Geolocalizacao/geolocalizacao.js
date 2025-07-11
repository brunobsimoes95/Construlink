window.getLocation = () => {
    return new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition(
            pos => resolve({
                isSuccess: true,
                latitude: pos.coords.latitude,
                longitude: pos.coords.longitude,
                message: "Localização obtida com sucesso"
            }),
            err => resolve({
                isSuccess: false,
                latitude: 0,
                longitude: 0,
                message: err.message
            })
        );
    });
};
