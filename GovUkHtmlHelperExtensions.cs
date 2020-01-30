using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.GovUkDesignSystemComponents.SubComponents;
using GovUkDesignSystem.HtmlGenerators;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovUkDesignSystem
{
    public static class GovUkHtmlHelperExtensions
    {

        public static IHtmlContent GovUkBackLink(
            this IHtmlHelper htmlHelper,
            BackLinkViewModel backLinkViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/BackLink.cshtml", backLinkViewModel);
        }

        public static IHtmlContent GovUkBreadcrumbs(
            this IHtmlHelper htmlHelper,
            BreadcrumbsViewModel breadcrumbsViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Breadcrumbs.cshtml", breadcrumbsViewModel);
        }

        public static IHtmlContent GovUkButton(
            this IHtmlHelper htmlHelper,
            ButtonViewModel buttonViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Button.cshtml", buttonViewModel);
        }

        public static IHtmlContent GovUkCharacterCount(
            this IHtmlHelper htmlHelper,
            CharacterCountViewModel characterCountViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/CharacterCount.cshtml", characterCountViewModel);
        }

        public static IHtmlContent GovUkCharacterCountFor<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, string>> propertyLambdaExpression,
            int? rows = null,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null)
            where TModel : GovUkViewModel
        {
            return CharacterCountHtmlGenerator.GenerateHtml(
                htmlHelper,
                propertyLambdaExpression,
                rows,
                labelOptions,
                hintOptions,
                formGroupOptions);
        }

        public static IHtmlContent GovUkCheckboxes(
            this IHtmlHelper htmlHelper,
            CheckboxesViewModel checkboxesViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Checkboxes.cshtml", checkboxesViewModel);
        }

        public static IHtmlContent GovUkCheckboxesFor<TModel, TPropertyListItem>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, List<TPropertyListItem>>> propertyLambdaExpression,
            FieldsetViewModel fieldsetOptions = null,
            HintViewModel hintOptions = null,
            Dictionary<TPropertyListItem, Func<object, object>> conditionalOptions = null
            )
            where TModel : GovUkViewModel
            where TPropertyListItem : struct, IConvertible // A fairly good check that TPropertyListItem is an Enum
        {
            return CheckboxesHtmlGenerator.GenerateHtml(
                htmlHelper,
                propertyLambdaExpression,
                fieldsetOptions,
                hintOptions,
                conditionalOptions);
        }

        public static IHtmlContent GovUkCheckboxItem(
            this IHtmlHelper htmlHelper,
            CheckboxItemViewModel checkboxItemViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/CheckboxItem.cshtml", checkboxItemViewModel);
        }

        public static IHtmlContent GovUkErrorMessage(
            this IHtmlHelper htmlHelper,
            ErrorMessageViewModel errorMessageViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/ErrorMessage.cshtml", errorMessageViewModel);
        }

        public static IHtmlContent GovUkErrorSummary(
            this IHtmlHelper htmlHelper,
            ErrorSummaryViewModel errorSummaryViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/ErrorSummary.cshtml", errorSummaryViewModel);
        }

        public static IHtmlContent GovUkErrorSummary(
            this IHtmlHelper htmlHelper,
            ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                return null;
            }

            var errorSummaryItems = modelState.SelectMany(ms => ms.Value.Errors.Select(e => new Tuple<string, string>(ms.Key, e.ErrorMessage)))
                .Select(tuple => new ErrorSummaryItemViewModel { Href = $"#GovUk_{tuple.Item1}-error", Text = tuple.Item2 })
                .ToList();

            var errorSummaryViewModel = new ErrorSummaryViewModel
            {
                Title = new ErrorSummaryTitle
                {
                    Text = "There is a problem"
                },
                Errors = errorSummaryItems
            };

            return htmlHelper.Partial("/GovUkDesignSystemComponents/ErrorSummary.cshtml", errorSummaryViewModel);
        }

        public static IHtmlContent GovUkErrorSummary<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            string[] optionalOrderOfPropertyNamesInTheView = null)
            where TModel : GovUkViewModel
        {
            // Give 'optionalOrderOfPropertiesInTheView' a default value (of an empty array)
            var orderOfPropertyNamesInTheView = optionalOrderOfPropertyNamesInTheView ?? new string[0];

            return ErrorSummaryHtmlGenerator.GenerateHtml(htmlHelper, orderOfPropertyNamesInTheView);
        }

        public static IHtmlContent GovUkFieldset(
            this IHtmlHelper htmlHelper,
            FieldsetViewModel fieldsetViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Fieldset.cshtml", fieldsetViewModel);
        }

        public static IHtmlContent GovUkFooter(
            this IHtmlHelper htmlHelper,
            FooterViewModel footerViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Footer.cshtml", footerViewModel);
        }

        public static IHtmlContent GovUkHeader(
            this IHtmlHelper htmlHelper,
            HeaderViewModel headerViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Header.cshtml", headerViewModel);
        }

        public static IHtmlContent GovUkHint(
            this IHtmlHelper htmlHelper,
            HintViewModel hintViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Hint.cshtml", hintViewModel);
        }

        public static IHtmlContent GovUkHtmlText(
            this IHtmlHelper htmlHelper,
            IHtmlText htmlText)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/SubComponents/HtmlText.cshtml", htmlText);
        }

        public static IHtmlContent GovUkInsetText(
            this IHtmlHelper htmlHelper,
            InsetTextViewModel insetTextViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/InsetText.cshtml", insetTextViewModel);
        }

        public static IHtmlContent GovUkItem(
            this IHtmlHelper htmlHelper,
            ItemViewModel itemViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Item.cshtml", itemViewModel);
        }

        public static IHtmlContent GovUkItemSet(
            this IHtmlHelper htmlHelper,
            ItemSetViewModel itemSetViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/ItemSet.cshtml", itemSetViewModel);
        }

        public static IHtmlContent GovUkLabel(
            this IHtmlHelper htmlHelper,
            LabelViewModel labelViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Label.cshtml", labelViewModel);
        }

        public static IHtmlContent GovUkLegend(
            this IHtmlHelper htmlHelper,
            LegendViewModel legendViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Legend.cshtml", legendViewModel);
        }

        public static IHtmlContent GovUkPhaseBanner(
            this IHtmlHelper htmlHelper,
            PhaseBannerViewModel phaseBannerViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/PhaseBanner.cshtml", phaseBannerViewModel);
        }

        public static async Task<IHtmlContent> GovUkRadiosFor<TModel, TEnum>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TEnum?>> propertyLambdaExpression,
            FieldsetViewModel fieldsetOptions = null,
            HintViewModel hintOptions = null)
            where TModel : class
            where TEnum : struct, Enum
        {
            return await RadiosHtmlGenerator.GenerateHtml(
                htmlHelper,
                propertyLambdaExpression,
                fieldsetOptions,
                hintOptions);
        }

        public static async Task<IHtmlContent> GovUkRadioItem(
            this IHtmlHelper htmlHelper,
            RadioItemViewModel radioItemViewModel)
        {
            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/RadioItem.cshtml", radioItemViewModel);
        }

        public static IHtmlContent GovUkTag(
            this IHtmlHelper htmlHelper,
            TagViewModel tagViewModel)
        {
            return htmlHelper.Partial("/GovUkDesignSystemComponents/Tag.cshtml", tagViewModel);
        }

        public static async Task<IHtmlContent> GovUkTextArea(
            this IHtmlHelper htmlHelper,
            TextAreaViewModel textAreaViewModel)
        {
            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/TextArea.cshtml", textAreaViewModel);
        }

        public static async Task<IHtmlContent> GovUkTextAreaFor<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, string>> propertyLambdaExpression,
            int? rows = null,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null)
            where TModel : GovUkViewModel
        {
            return await TextAreaHtmlGenerator.GenerateHtml(
                htmlHelper,
                propertyLambdaExpression,
                rows,
                labelOptions,
                hintOptions,
                formGroupOptions);
        }

        public static async Task<IHtmlContent> GovUkTextInput(
            this IHtmlHelper htmlHelper,
            TextInputViewModel textInputViewModel)
        {
            return await htmlHelper.PartialAsync("/GovUkDesignSystemComponents/TextInput.cshtml", textInputViewModel);
        }

        public static async Task<IHtmlContent> GovUkTextInputFor<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, string>> propertyLambdaExpression,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null,
            string classes = null,
            TextInputAppendixViewModel textInputAppendix = null)
            where TModel : GovUkViewModel
        {
            return await TextInputHtmlGenerator.GenerateHtml(
                htmlHelper,
                propertyLambdaExpression,
                labelOptions,
                hintOptions,
                formGroupOptions,
                classes,
                textInputAppendix);
        }

        public static async Task<IHtmlContent> GovUkTextInputFor<TModel>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, int?>> propertyExpression,
            LabelViewModel labelOptions = null,
            HintViewModel hintOptions = null,
            FormGroupViewModel formGroupOptions = null,
            string classes = null,
            TextInputAppendixViewModel textInputAppendix = null)
            where TModel : class
        {
            return await TextInputHtmlGenerator.GenerateHtml(
                htmlHelper,
                propertyExpression,
                labelOptions,
                hintOptions,
                formGroupOptions,
                classes,
                textInputAppendix);
        }
    }
}