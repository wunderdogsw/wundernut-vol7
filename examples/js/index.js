const _ = require('lodash')
const data = require('./resources/data.json')

const LOSS_PER_SHARD = -1;

const solve = function(data) {
    return _.map(data, function(diamond) {
        const cuts = diamond.cuts
        const chunks = diamond.rawChunks
        const totalValue = _.reduce(chunks, function(total, chunk) {

            const optimalStrategy = { normalizedValue: 0, path: [] }
            calculateOptimalCutStrategy(chunk, cuts, 0, optimalStrategy, [])

            // calculate profit and loss with optimal strategy
            const loss = (chunk - _.sumBy(optimalStrategy.path, 'size')) * LOSS_PER_SHARD
            const profit = _.sumBy(optimalStrategy.path, 'value')

            return total + profit + loss
        }, 0)
        return totalValue
    })
}

// recursively calculate best possible cut strategies for a chunk
const calculateOptimalCutStrategy = function(chunk, cuts, currentValue, optimalStrategy, path) {
    _.forEach(cuts, function(cut) {
        const newPath = _.concat(path, cut)
        const value = cut.value
        const remaining = chunk - cut.size
        var newCurrentValue = currentValue + value

        // if chunk can't be made to valued cuts, strategy path ends
        if(remaining < 0) return

        // calculate normalized path value (value minus loss if no more cuts are made)
        const normalizedValue = newCurrentValue + (remaining * LOSS_PER_SHARD)

        // update optimal strategy path
        if(normalizedValue > optimalStrategy.normalizedValue) {
            optimalStrategy.normalizedValue = normalizedValue
            optimalStrategy.path = newPath
        }

        calculateOptimalCutStrategy(remaining, cuts, newCurrentValue, optimalStrategy, newPath)
    })
}

module.exports = (function() {
    console.log(_.sum(solve(data)))
})()
