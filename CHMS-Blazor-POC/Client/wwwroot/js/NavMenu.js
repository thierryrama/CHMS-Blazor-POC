export function initializeWETMenuPlugin() {
    console.debug("Initializing WET menu plugin");

    $(".wb-menu").trigger("wb-init.wb-menu");
}