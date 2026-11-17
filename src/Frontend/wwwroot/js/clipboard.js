window.vvSecurity = {
    copyText: async (text) => {
        await navigator.clipboard.writeText(text);
    },
    setLanguage: (language) => {
        document.documentElement.lang = language;
    },
    setDarkMode: (isDarkMode) => {
        if (isDarkMode) {
            document.documentElement.dataset.theme = "dark";
        } else {
            delete document.documentElement.dataset.theme;
        }
    }
};
