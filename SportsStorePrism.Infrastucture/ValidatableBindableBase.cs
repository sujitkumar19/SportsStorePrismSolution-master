﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using System.ComponentModel;
using System.Collections;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace SportsStorePrism.Infrastucture
{
  public class ValidatableBindableBase : BindableBase, INotifyDataErrorInfo
  {
    private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

    public bool HasErrors => _errors.Count > 0;

    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

    public IEnumerable GetErrors(string propertyName)
    {
      if (_errors.ContainsKey(propertyName)) return _errors[propertyName];

      return null;
    }

    protected override bool SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
    {
      base.SetProperty(ref member, val, propertyName);
      ValidateProperty(propertyName, val);
      return true;
    }

    #region Old
    //protected override void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
    //{
    //    base.SetProperty(ref member, val, propertyName);
    //    ValidateProperty(propertyName, val);
    //}

    #endregion
    private void ValidateProperty<T>(string propertyName, T value)
    {
      //Using the DataAnotations of .Net for validation

      var results = new List<ValidationResult>();

      //This is the class which will map and point to the DataAnotations of the called property
      ValidationContext context = new ValidationContext(this);
      context.MemberName = propertyName;
      Validator.TryValidateProperty(value, context, results);
      if (results.Any())
      {
        _errors[propertyName] = results.Select(c => c.ErrorMessage).ToList();
      }
      else
      {
        _errors.Remove(propertyName);
      }
      ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
    }
  }
}
