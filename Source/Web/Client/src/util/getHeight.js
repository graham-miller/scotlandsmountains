import $ from 'jquery';

const getHeight = function() {

    const allowance = 85; 
    const minimum = 200; 
    const windowHeight = $(window).height();

    var height = windowHeight - allowance;
    height = height < minimum ? minimum : height;

    return height;
}

export default getHeight;