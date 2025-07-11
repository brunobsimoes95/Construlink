window.fullCalendarObras = {
    instance: null,

    destroy: function () {
        if (this.instance) {
            this.instance.destroy();
            this.instance = null;
            console.log("🧹 FullCalendar destruído");
        }
    },

    init: function (colaboradores, eventos, mes) {
        this.destroy();

        const calendarEl = document.getElementById('calendario-obras');
        const defaultDate = new Date(new Date().getFullYear(), mes - 1, 1);

        this.instance = new FullCalendar.Calendar(calendarEl, {
            initialView: 'dayGridMonth',
            locale: 'pt',
            themeSystem: 'standard',
            headerToolbar: {
                left: '',
                center: 'title',
                right: ''
            },
            initialDate: defaultDate,
            events: eventos.map(e => ({
                id: e.id,
                title: e.title,
                start: e.start,
                end: e.end,
                extendedProps: {
                    obraCodigo: e.data?.obraCodigo
                }
            })),
            eventClick: function (info) {
                const obraCodigo = info.event.extendedProps.obraCodigo;
                if (!obraCodigo) return;
                window.location.href = `/Empreendimento/Editar/null/${obraCodigo}`;
            }
        });

        this.instance.render();
        console.log("📅 FullCalendar inicializado");
    }
};
