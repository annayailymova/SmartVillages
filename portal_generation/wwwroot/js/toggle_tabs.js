const tabs = document.querySelectorAll("div[id^='tab-']");
const triggers = document.querySelectorAll("div[id^='trigger-tab-']");

function switch_tab(trigger_id) {
    const tab_id = trigger_id.split('-').slice(-2).join('-')
    
    triggers.forEach((trigger) => {
        trigger.classList.remove('border-b-4')
        
        if (trigger.id === trigger_id)
            trigger.classList.add('border-b-4')
    })

    tabs.forEach((tab) => {
        tab.classList.add('hidden')

        if (tab.id === tab_id)
            tab.classList.remove('hidden')
    })
}
