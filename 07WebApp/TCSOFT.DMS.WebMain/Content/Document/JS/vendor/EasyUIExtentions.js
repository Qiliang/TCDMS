$.parser.plugins.push("distributortbox");//注册扩展组件
$.fn.distributortbox = function (options, param) {//定义扩展组件

// 当options为字符串时，说明执行的是该插件的方法。
if (typeof options == "string") { return $.fn.combobox.apply(this, arguments); }
options = options || {};

// 当该组件在一个页面出现多次时，this是一个集合，故需要通过each遍历。
    return this.each(function () {
        var jq = $(this);
        var opts = $.extend({}, $.fn.combobox.parseOptions(this), options);
        var myopts = $.extend(true, {
            editable: true,
            mode:'remote',
            url: "/Common/GetDistributorBaseInfo",
            hasDownArrow: false,
            valueField: 'DistributorID',
            textField: 'DistributorName',
            onBeforeLoad: function (param) {
                if (param == null || param.q == null || param.q.replace(/ /g, '') == '') {
                    var value = $(this).combobox('getValue');
                    if (value) {
                        param.id = value;
                        return true;
                    }
                    return false;
                }
            }

        }, opts);
        $.fn.combobox.call(jq, myopts);
    });
};
