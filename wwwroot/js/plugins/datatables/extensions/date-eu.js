/**
 * Similar to the Date (dd/mm/YY) data sorting plug-in, this plug-in offers 
 * additional  flexibility with support for spaces between the values and
 * either . or / notation for the separators.
 *
 * Please note that this plug-in is **deprecated*. The
 * [datetime](//datatables.net/blog/2014-12-18) plug-in provides enhanced
 * functionality and flexibility.
 *
 *  @name Date (dd . mm[ . YYYY]) 
 *  @summary Sort dates in the format `dd/mm/YY[YY]` (with optional spaces)
 *  @author [Robert Sedovšek](http://galjot.si/)
 *  @deprecated
 * 
 *  Alterado por
 *	@author [Domingos Ferreira]
 *	para fazer sort pelo datetime e não só pelo date
 *
 *  @example
 *    $('#example').dataTable( {
 *       columnDefs: [
 *         { type: 'date-eu', targets: 0 }
 *       ]
 *    } );
 */

jQuery.extend( jQuery.fn.dataTableExt.oSort, {
	"date-eu-pre": function ( date ) {
		date = date.replace(" ", "");
		
		if ( ! date ) {
			return 0;
		}

		var year;
		var eu_date = date.split(/[\.\-\/]/);

		/*year (optional)*/
		if ( eu_date[2] ) {
			year = eu_date[2];
		}
		else {
			year = 0;
		}

		/*month*/
		var month = eu_date[1];
		if ( month.length == 1 ) {
			month = 0+month;
		}

		/*day*/
		var day = eu_date[0];
		if ( day.length == 1 ) {
			day = 0+day;
		}

		return (year + month + day) * 1;
	},

	"date-eu-asc": function ( a, b ) {
		return ((a < b) ? -1 : ((a > b) ? 1 : 0));
	},

	"date-eu-desc": function ( a, b ) {
		return ((a < b) ? 1 : ((a > b) ? -1 : 0));
	}
});

//Nova função para fazer o sort pelo datetime
jQuery.extend(jQuery.fn.dataTableExt.oSort, {
	"datetime-eu-pre": function (date) {
		if (!date) {
			return 0;
		}

		var dateTimeParts = date.split(' ');
		var datePart = dateTimeParts[0];
		var timePart = dateTimeParts[1] ? dateTimeParts[1].replace(":", "") : "000000";

		var eu_date = datePart.split(/[\.\-\/]/),
			year = eu_date[2] || 0,
			month = eu_date[1].length === 1 ? '0' + eu_date[1] : eu_date[1],
			day = eu_date[0].length === 1 ? '0' + eu_date[0] : eu_date[0],
			time = timePart.length === 6 ? timePart : "000000";

		return (year + month + day + time) * 1;
	},

	"datetime-eu-asc": function (a, b) {
		return ((a < b) ? -1 : ((a > b) ? 1 : 0));
	},

	"datetime-eu-desc": function (a, b) {
		return ((a < b) ? 1 : ((a > b) ? -1 : 0));
	}
});

