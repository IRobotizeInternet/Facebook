﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using RobotizeLibrary.CommonControls;
using RobotizeLibrary.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotizeLibrary.Controls.Grid
{
    public class CheckboxFilter: BaseFilter, ICheckboxFilterOptions, ICheckboxFilter
    {
        private readonly By _byFilterButton;

        public CheckboxFilter(RemoteWebDriver driver, WebDriverWait wait, By byFilterButton)
            : base(driver, wait)
        {
            _byFilterButton = byFilterButton;
        }

        public IEnumerable<string> FilterCriteriaList { get; private set; }

        public IApplyFilter FilterItemList(IEnumerable<string> itemsToFilter)
        {
            FilterCriteriaList = itemsToFilter;
            return this;
        }

        public override void ApplyFilter()
        {
            if (FilterCriteriaList.Any()) SetFilterCriteria();
            base.ApplyFilter();
        }

        protected override void ClickFilterButton()
        {
            var button = new Button(Driver, _byFilterButton);
            button.Click();
        }

        protected override void SetFilterCriteria()
        {
            UnSelectAll();
            foreach (var criteria in FilterCriteriaList)
            {
                SetFilterElementLabel(criteria);
            }
        }

        private void SetFilterElementLabel(string filterExpression)
        {
            const string xpathForLabelsFilterPopup =
                "//form[@class='k-filter-menu']" +
                "//label";
            var labelElementsFilterPopup = Driver.FindVisibleElementsWait(By.XPath(xpathForLabelsFilterPopup));

            var checkboxItemToClick = labelElementsFilterPopup.First(labelElement => labelElement.Text.Trim()
                .Equals(filterExpression));

            if (checkboxItemToClick == null) throw new ElementNotVisibleException($"Unable to add filter {filterExpression}. checkbox filter not available");

            checkboxItemToClick.Click();
        }

        private void UnSelectAll()
        {
            const string xpathForCheckboxesFilterPopup =
                "//form[@class='k-filter-menu']" +
                "//input[@type='checkbox']";
            var checkboxElementsOnFilterPopup = Driver.FindElements(By.XPath(xpathForCheckboxesFilterPopup));
            var checkedCheckboxes = checkboxElementsOnFilterPopup.Where(checkbox => checkbox.Selected);
            foreach (var checkbox in checkedCheckboxes)
            {
                checkbox.Click();
            }
        }

        private void SelectAll()
        {

        }

        public IApplyFilter InteriorColor(string interiorColor)
        {
            throw new NotImplementedException();
        }

        public ICheckboxFilterOptions FilterBy => throw new NotImplementedException();
    }
}
