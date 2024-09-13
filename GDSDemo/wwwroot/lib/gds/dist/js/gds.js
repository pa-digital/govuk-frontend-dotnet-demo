document.addEventListener("DOMContentLoaded", function () {
    const toggleButtons = document.querySelectorAll('.govuk-js-password-input-toggle');

    toggleButtons.forEach(button => {
        button.removeAttribute('hidden');
        button.addEventListener('click', function () {
            const passwordInput = this.previousElementSibling;
            if (passwordInput.type === 'password') {
                passwordInput.type = 'text';
                this.textContent = 'Hide';
            } else {
                passwordInput.type = 'password';
                this.textContent = 'Show';
            }
        });
    });
});

document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.govuk-fieldset').forEach(fieldset => {
        const checkboxes = fieldset.querySelectorAll('.govuk-checkboxes__input');

        checkboxes.forEach(checkbox => {
            checkbox.addEventListener('change', function () {
                if (this.dataset.module === 'exclusivecheck' && this.checked) {
                    checkboxes.forEach(cb => {
                        if (cb !== this) {
                            cb.checked = false;
                        }
                    });
                } else if (this.dataset.module !== 'exclusivecheck' && this.checked) {
                    checkboxes.forEach(cb => {
                        if (cb.dataset.module === 'exclusivecheck') {
                            cb.checked = false;
                        }
                    });
                }
            });
        });
    });
});

function addRegexValidation(order, fieldName, pattern, errorMessage) {
    window.regexValidations = window.regexValidations || {};
    window.regexValidations[fieldName] = { order, pattern: new RegExp(pattern), errorMessage: errorMessage };
}

function addRequiredValidation(order, fieldName, errorMessage, isGroupElement = false) {
    window.requiredValidations = window.requiredValidations || {};
    window.requiredValidations[fieldName] = { order, errorMessage, isGroupElement };
}

function addDateInputRequiredValidation(order, fieldName, errorMessage) {
    window.requiredDateInputValidations = window.requiredDateInputValidations || {};
    window.requiredDateInputValidations[fieldName] = { order, errorMessage };
}

function addDateInputFutureValidation(order, fieldName, errorMessage) {
    window.futureDateInputValidations = window.futureDateInputValidations || {};
    window.futureDateInputValidations[fieldName] = { order, errorMessage };
}

function addDateInputPastValidation(order, fieldName, errorMessage) {
    window.pastDateInputValidations = window.pastDateInputValidations || {};
    window.pastDateInputValidations[fieldName] = { order, errorMessage };
}

function validateForm() {
    let hasErrors = false;
    const errorSummary = [];

    function addError(order, field, errorMessage, isGroup = false) {
        const formGroup = field.closest('.govuk-form-group');
        if (formGroup) {
            formGroup.classList.add('govuk-form-group--error');
        }

        const fieldIdBase = isGroup
            ? field.type === 'radio'
                ? field.name.split('.')[0]
                : field.name.split('[')[0]
            : field.id;

        const errorFieldId = `${fieldIdBase}-error`;
        const errorSummaryId = isGroup ? `${fieldIdBase}-0` : fieldIdBase;

        let errorField = document.querySelector(`#${errorFieldId}`);

        if (!errorField) {
            const errorMessageElement = document.createElement('p');
            errorMessageElement.id = errorFieldId;
            errorMessageElement.className = 'govuk-error-message';
            errorMessageElement.innerHTML = `<span class="govuk-visually-hidden">Error:</span> ${errorMessage}`;

            if (isGroup) {
                const legend = formGroup.querySelector('legend');
                if (legend) {
                    legend.insertAdjacentElement('afterend', errorMessageElement);
                } else {
                    field.insertAdjacentElement('beforebegin', errorMessageElement);
                }
            } else if (field.autocomplete === 'current-password') {
                const passwordWrapper = field.closest('.govuk-input__wrapper.govuk-password-input__wrapper');
                if (passwordWrapper) {
                    passwordWrapper.insertAdjacentElement('beforebegin', errorMessageElement);
                } else {
                    field.insertAdjacentElement('beforebegin', errorMessageElement);
                }
            } else {
                field.insertAdjacentElement('beforebegin', errorMessageElement);
            }
        }

        errorSummary.push({ order, errorMessage, errorSummaryId });
        hasErrors = true;
    }

    function addDateInputError(order, field, errors, errorMessage) {
        const fieldIdBase = field.toString().toLowerCase();
        const errorFieldId = `${fieldIdBase}-error`;
        let appendedTag = false;
        let errorField = document.querySelector(`#${errorFieldId}`);
        const appendErrorMessage = errors.some(error => error.type === 'Reg') || errors.every(error => error.type === 'Num') || errors.length < 3;
        if (appendErrorMessage) {
            errorMessage = "Valid " + errorMessage;
        }
        errors.forEach(error => {
            const element = document.querySelector(`#${error.id}`);
            element.classList.add('govuk-input--error');
            if (appendErrorMessage) {
                const elementLabel = error.id.split('_')[1];
                if (!appendedTag) {
                    errorMessage += " You are missing a ";
                    if (error.type === "Num") {
                        errorMessage += "numeric "
                    } else {
                        errorMessage += "valid numeric "
                    }
                    errorMessage += elementLabel[0].toUpperCase() + elementLabel.slice(1);
                    appendedTag = true;
                } else {
                    errorMessage += ", a ";
                    if (error.type === "Num") {
                        errorMessage += "numeric "
                    } else {
                        errorMessage += "valid numeric "
                    }
                    errorMessage += elementLabel[0].toUpperCase() + elementLabel.slice(1);
                }
            }
        });
        if (appendedTag) {
            var n = errorMessage.lastIndexOf(", a");
            var remaining = errorMessage.slice(n + 3);
            if (n >= 0 && n + errorMessage.length >= errorMessage.length) {
                errorMessage = errorMessage.substring(0, n) + " and a";
                errorMessage += remaining + ".";
            }
        }

        const inputWrapper = document.querySelector(`#${fieldIdBase}`);
        if (!errorField) {
            const errorMessageElement = document.createElement('p');
            errorMessageElement.id = errorFieldId;
            errorMessageElement.className = 'govuk-error-message';
            errorMessageElement.innerHTML = `<span class="govuk-visually-hidden">Error:</span> ${errorMessage}`;


            if (inputWrapper) {
                inputWrapper.insertAdjacentElement('beforebegin', errorMessageElement);
            }
        }

        const formGroup = inputWrapper.closest('.govuk-form-group');
        if (formGroup) {
            formGroup.classList.add('govuk-form-group--error');
        }

        errorSummary.push({ order, errorMessage, fieldIdBase });
        hasErrors = true;
    }

    function removeError(field, isGroup = false) {
        const formGroup = field.closest('.govuk-form-group');
        const fieldIdBase = isGroup
            ? field.type === 'radio'
                ? field.name.split('.')[0]
                : field.name.split('[')[0]
            : field.id;
        const errorFieldId = `${fieldIdBase}-error`;
        const errorField = document.querySelector(`#${errorFieldId}`);

        if (errorField) {
            errorField.remove();
        }

        if (formGroup && !formGroup.querySelector('.govuk-error-message')) {
            formGroup.classList.remove('govuk-form-group--error');
        }
    }

    function removeDateInputError(field) {
        const fieldIdBase = field;
        const errorField = document.querySelector(`#${fieldIdBase.toLowerCase()}-error`);
        if (errorField) {
            errorField.remove();
        }
        const day = document.querySelector(`#${fieldIdBase}_Day`);
        if (day) {
            day.classList.remove('govuk-input--error');
        }
        const month = document.querySelector(`#${fieldIdBase}_Month`);
        if (month) {
            month.classList.remove('govuk-input--error');
        }
        const year = document.querySelector(`#${fieldIdBase}_Year`);
        if (year) {
            year.classList.remove('govuk-input--error');
        }
        const fieldset = day.closest('.govuk-fieldset');
        if (fieldset) {
            var formWrapper = fieldset.closest('.govuk-form-group');
            if (formWrapper) {
                formWrapper.classList.remove('govuk-form-group--error');
            }
        }
    }

    const existingErrorSummary = document.querySelector('.govuk-error-summary');
    if (existingErrorSummary) {
        existingErrorSummary.remove();
    }

    const processedFields = new Set();
    Object.keys(window.requiredValidations || {}).forEach(fieldName => {
        const fields = document.querySelectorAll(`[name^='${fieldName}']`);
        const { order, errorMessage, isGroupElement } = window.requiredValidations[fieldName];

        if (isGroupElement && fields[0].type === 'radio' || isGroupElement && fields[0].type === 'checkbox') {
            const isChecked = Array.from(fields).some(field => field.checked);

            removeError(fields[0], true);

            if (!isChecked) {
                addError(order, fields[0], errorMessage, true);
                processedFields.add(fieldName);
            }
        } else if (isGroupElement && fields[0].type === 'select-one') {
            const isSelected = fields[0].value !== '';
            removeError(fields[0]);

            if (!isSelected) {
                addError(order, fields[0], errorMessage);
                processedFields.add(fieldName);
            }
        } else {
            fields.forEach(field => {
                removeError(field);

                if (!field.value.trim()) {
                    addError(order, field, errorMessage);
                    processedFields.add(fieldName);
                }
            });
        }
    });

    Object.keys(window.requiredDateInputValidations || {}).forEach(nonFixedFieldName => {
        const fieldName = nonFixedFieldName.split(".")[0];
        if (processedFields.has(fieldName)) {
            return;
        }
        const fields = document.querySelectorAll(`[name^='${fieldName}']`);
        const { order, errorMessage } = window.requiredDateInputValidations[nonFixedFieldName];
        const errors = [];
        let iterator = 0;
        removeDateInputError(fieldName);
        fields.forEach(field => {
            if (!field.value.trim()) {
                errors.push({ id: field.id, type: 'Req' });
            } else {
                let pattern = new RegExp('^[0-9]{4}$');
                var result = tryParseInt(field.value);
                if (result.success) {
                    const fieldType = field.id.split("_")[1];
                    if (fieldType === "Day") {
                        pattern = new RegExp('^(0?[1-9]|[12][0-9]|3[01])$');
                    }
                    if (fieldType === "Month") {
                        pattern = new RegExp('^(0?[1-9]|1[0-2])$');
                    }
                    if (!pattern.test(result.value)) {
                        errors.push({ id: field.id, type: 'Reg' });
                    }
                } else {
                    errors.push({ id: field.id, type: 'Num' });
                }
            };
            iterator++;
        });
        if (errors.length > 0 && iterator == 3) {
            addDateInputError(order, fieldName, errors, errorMessage);
            processedFields.add(fieldName);
        }
    });

    Object.keys(window.futureDateInputValidations || {}).forEach(nonFixedFieldName => {
        const fieldName = nonFixedFieldName.split(".")[0];
        if (processedFields.has(fieldName)) {
            return;
        }
        const fields = document.querySelectorAll(`[name^='${fieldName}']`);
        const { order, errorMessage } = window.futureDateInputValidations[nonFixedFieldName];
        const errors = [];
        removeDateInputError(fieldName);

        var day, month, year;
        fields.forEach(field => {
            const fieldType = field.id.split("_")[1];
            var result = tryParseInt(field.value);
            if (result.success) {
                if (fieldType === "Day") {
                    day = result.value;
                }
                if (fieldType === "Month") {
                    month = result.value;
                }
                if (fieldType === "Year") {
                    year = result.value;
                }
                errors.push({ id: field.id, type: 'Future' });
            }
        });

        if (!isNaN(day) && !isNaN(month) && !isNaN(year)) {
            var checkDate = new Date(year, month - 1, day);

            var today = new Date();
            today.setHours(0, 0, 0, 0);

            if (checkDate >= today) {
                errors.length = 0;
            }
        }

        if (errors.length > 0) {
            addDateInputError(order, fieldName, errors, errorMessage);
            processedFields.add(fieldName);
        }
    });

    Object.keys(window.pastDateInputValidations || {}).forEach(nonFixedFieldName => {
        const fieldName = nonFixedFieldName.split(".")[0];
        if (processedFields.has(fieldName)) {
            return;
        }
        const fields = document.querySelectorAll(`[name^='${fieldName}']`);
        const { order, errorMessage } = window.pastDateInputValidations[nonFixedFieldName];
        const errors = [];
        removeDateInputError(fieldName);

        var day, month, year;
        fields.forEach(field => {
            const fieldType = field.id.split("_")[1];
            var result = tryParseInt(field.value);
            if (result.success) {
                if (fieldType === "Day") {
                    day = result.value;
                }
                if (fieldType === "Month") {
                    month = result.value;
                }
                if (fieldType === "Year") {
                    year = result.value;
                }
                errors.push({ id: field.id, type: 'Past' });
            }
        });

        if (!isNaN(day) && !isNaN(month) && !isNaN(year)) {
            var checkDate = new Date(year, month - 1, day);

            var today = new Date();
            today.setHours(0, 0, 0, 0);

            if (checkDate <= today) {
                errors.length = 0;
            }
        }

        if (errors.length > 0) {
            addDateInputError(order, fieldName, errors, errorMessage);
            processedFields.add(fieldName);
        }
    });

    Object.keys(window.regexValidations || {}).forEach(fieldName => {
        if (processedFields.has(fieldName)) {
            return;
        }
        const fields = document.querySelectorAll(`[name='${fieldName}']`);
        fields.forEach(field => {
            const { order, pattern, errorMessage } = window.regexValidations[fieldName];

            removeError(field);

            if (!pattern.test(field.value)) {
                addError(order, field, errorMessage);
            }
        });
    });

    if (hasErrors) {
        const errorSummaryContainer = document.createElement('div');
        errorSummaryContainer.className = 'govuk-error-summary';
        errorSummaryContainer.setAttribute('data-module', 'govuk-error-summary');
        errorSummaryContainer.setAttribute('role', 'alert');

        const errorSummaryTitle = document.createElement('h2');
        errorSummaryTitle.className = 'govuk-error-summary__title';
        errorSummaryTitle.innerText = 'There is a problem';

        const errorSummaryBody = document.createElement('div');
        errorSummaryBody.className = 'govuk-error-summary__body';

        const errorSummaryList = document.createElement('ul');
        errorSummaryList.className = 'govuk-list govuk-error-summary__list';

        errorSummary.sort((a, b) => a.order - b.order).forEach(({ errorMessage, errorSummaryId }) => {
            const listItem = document.createElement('li');
            const errorLink = document.createElement('a');
            errorLink.href = `#${errorSummaryId}`;
            errorLink.innerText = errorMessage;
            listItem.appendChild(errorLink);
            errorSummaryList.appendChild(listItem);
        });

        errorSummaryBody.appendChild(errorSummaryList);
        errorSummaryContainer.appendChild(errorSummaryTitle);
        errorSummaryContainer.appendChild(errorSummaryBody);

        const gridColumnFull = document.createElement('div');
        gridColumnFull.className = 'govuk-grid-column-full';
        gridColumnFull.appendChild(errorSummaryContainer);

        const gridRow = document.createElement('div');
        gridRow.className = 'govuk-grid-row';
        gridRow.appendChild(gridColumnFull);

        const firstFormGroup = document.querySelector('.govuk-form-group');
        if (firstFormGroup) {
            const firstGridColumn = firstFormGroup.closest('[class^="govuk-grid-column"]');
            const firstGridRow = firstGridColumn.closest('.govuk-grid-row');
            firstGridRow.insertAdjacentElement('beforebegin', gridRow);
        }
    }

    function tryParseInt(str) {
        var parsed = parseInt(str, 10);
        if (isNaN(parsed)) {
            return { success: false, value: NaN };
        } else {
            return { success: true, value: parsed };
        }
    }

    return !hasErrors;
}


document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('form');
    if (form) {
        form.addEventListener('submit', function (event) {
            if (!validateForm()) {
                event.preventDefault();
            }
        });
    }
});

document.addEventListener('DOMContentLoaded', function () {
    const accordion = document.querySelector('.govuk-accordion');

    if (accordion) {
        const accordionSections = accordion.querySelectorAll('.govuk-accordion__section');

        if (accordionSections.length > 0) {
            const controlsDiv = document.createElement('div');
            controlsDiv.className = 'govuk-accordion__controls';
            controlsDiv.innerHTML = `
                <button type="button" class="govuk-accordion__show-all" aria-expanded="false">
                    <span class="govuk-accordion-nav__chevron govuk-accordion-nav__chevron--down"></span>
                    <span class="govuk-accordion__show-all-text">Show all sections</span>
                </button>
            `;
            accordion.insertBefore(controlsDiv, accordion.firstChild);

            const showAllButton = controlsDiv.querySelector('.govuk-accordion__show-all');

            function toggleSection(section, expand) {
                const button = section.querySelector('.govuk-accordion__section-button');
                const content = section.querySelector('.govuk-accordion__section-content');
                const headingText = button.querySelector('.govuk-accordion__section-heading-text-focus').textContent.trim();
                const chevron = button.querySelector('.govuk-accordion-nav__chevron');

                if (expand) {
                    content.removeAttribute('hidden');
                    section.classList.add('govuk-accordion__section--expanded');
                    button.setAttribute('aria-expanded', 'true');
                    button.setAttribute('aria-label', `${headingText}, Hide this section`);
                    button.querySelector('.govuk-accordion__section-toggle-text').textContent = 'Hide';
                    chevron.classList.remove('govuk-accordion-nav__chevron--down');
                    chevron.classList.add('govuk-accordion-nav__chevron--up');
                } else {
                    content.setAttribute('hidden', 'hidden');
                    section.classList.remove('govuk-accordion__section--expanded');
                    button.setAttribute('aria-expanded', 'false');
                    button.setAttribute('aria-label', `${headingText}, Show this section`);
                    button.querySelector('.govuk-accordion__section-toggle-text').textContent = 'Show';
                    chevron.classList.remove('govuk-accordion-nav__chevron--up');
                    chevron.classList.add('govuk-accordion-nav__chevron--down');
                }
            }
            showAllButton.addEventListener('click', function () {
                const expand = showAllButton.getAttribute('aria-expanded') === 'false';
                accordionSections.forEach(section => toggleSection(section, expand));

                showAllButton.setAttribute('aria-expanded', expand ? 'true' : 'false');
                showAllButton.querySelector('.govuk-accordion__show-all-text').textContent = expand ? 'Hide all sections' : 'Show all sections';
                const chevron = showAllButton.querySelector('.govuk-accordion-nav__chevron');
                if (expand) {
                    chevron.classList.remove('govuk-accordion-nav__chevron--down');
                    chevron.classList.add('govuk-accordion-nav__chevron--up');
                } else {
                    chevron.classList.remove('govuk-accordion-nav__chevron--up');
                    chevron.classList.add('govuk-accordion-nav__chevron--down');
                }
            });

            accordionSections.forEach((section, index) => {
                const header = section.querySelector('.govuk-accordion__section-heading');
                const spanButton = header.querySelector('.govuk-accordion__section-button');
                const content = section.querySelector('.govuk-accordion__section-content');
                const headingText = spanButton.textContent.trim();

                const button = document.createElement('button');
                button.type = 'button';
                button.className = 'govuk-accordion__section-button';
                button.setAttribute('aria-controls', `accordion-default-content-${index}`);
                button.setAttribute('aria-expanded', 'false');
                button.setAttribute('aria-label', `${headingText}, Show this section`);

                button.innerHTML = `
                    <span class="govuk-accordion__section-heading-text" id="accordion-default-heading-${index}">
                        <span class="govuk-accordion__section-heading-text-focus">
                            ${headingText}
                        </span>
                    </span>
                    <span class="govuk-visually-hidden govuk-accordion__section-heading-divider">, </span>
                    <span class="govuk-accordion__section-toggle" data-nosnippet="">
                        <span class="govuk-accordion__section-toggle-focus">
                            <span class="govuk-accordion-nav__chevron govuk-accordion-nav__chevron--down"></span>
                            <span class="govuk-accordion__section-toggle-text">Show</span>
                        </span>
                    </span>
                `;

                header.replaceChild(button, spanButton);
                content.setAttribute('hidden', 'hidden');

                button.addEventListener('click', function () {
                    const expand = content.hasAttribute('hidden');
                    toggleSection(section, expand);
                });
            });
        }
    }
});

document.addEventListener("DOMContentLoaded", function () {
    const tabListItems = document.querySelectorAll(".govuk-tabs__list-item");

    tabListItems.forEach(item => {
        item.addEventListener("click", function (event) {
            event.preventDefault();

            tabListItems.forEach(sibling => {
                sibling.classList.remove("govuk-tabs__list-item--selected");
            });

            this.classList.add("govuk-tabs__list-item--selected");

            const tabContentPanels = document.querySelectorAll(".govuk-tabs__panel");
            const targetId = this.querySelector("a").getAttribute("href").substring(1);

            tabContentPanels.forEach(panel => {
                if (panel.id === targetId) {
                    panel.classList.remove("govuk-tabs__panel--hidden");
                } else {
                    panel.classList.add("govuk-tabs__panel--hidden");
                }
            });
        });
    });
});