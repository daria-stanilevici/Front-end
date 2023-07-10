function SchemeBank(options) {
  let self = this;

  this.config = SchemeBank.mergeSettings(options);
  this.selector = typeof this.config.selector === 'string' ? document.querySelector(this.config.selector) : this.config.selector;

  ['itemClickHandler'].forEach(function (method) {
    self[method] = self[method].bind(self);
  });

  this.init();
}

SchemeBank.mergeSettings = function(options) {
  let settings = {
    selector: '.scheme',
    onInit: function() {},
    onItemClick: function(schema, item) {}
  };
  let userSttings = options;
  for (let attrname in userSttings) {
    settings[attrname] = userSttings[attrname];
  }
  return settings;
}

SchemeBank.prototype.init = function() {
  if (this.selector === null) {
    throw new Error('Something wrong with your selector 😭');
  }
  
  this.selector.addEventListener('click', this.itemClickHandler);
}

SchemeBank.prototype.itemClickHandler = function(event) {
  let target = event.target;
  
  if (!target.closest('.scheme__outer-item-inner')) {
    return;
  }
  target.parentNode.classList.toggle('open');
  this.config.onItemClick.call(this, this, target);
}

let mySchema = new SchemeBank({
  onItemClick: function(schema, item) {
    console.log(schema);
    console.log(item);
  }
});